using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.SeedWork;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ShoppingApp.Application.Configuration.UnitOfWork
{
    public class UnitOfWorkPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingAppContext _shoppingAppContext;
        public UnitOfWorkPipelineBehaviour(IUnitOfWork unitOfWork, ShoppingAppContext shoppingAppContext)
        {
            _unitOfWork = unitOfWork;
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                bool isCommand = IsCommand(request);
                if (isCommand)
                {
                    return await ProcessCommand(request, cancellationToken, next);
                }

                return await ProcessQuery(request, cancellationToken, next);                
            }
            catch (Exception e)
            {
                //TODO logs
                throw e;
            }
        }

        private async Task<TResponse> ProcessQuery(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return await next();
        }

        private async Task<TResponse> ProcessCommand(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (var transaction = _shoppingAppContext.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                TResponse response = await next();
                await _unitOfWork.CommitAsync();
                await transaction.CommitAsync();
                return response;
            }
        }

        private static bool IsCommand(TRequest request)
        {
            return request.GetType().GetInterfaces()
                .Any(x =>
                    x is ICommand
                    || (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICommand<>)));
        }
    }
}
