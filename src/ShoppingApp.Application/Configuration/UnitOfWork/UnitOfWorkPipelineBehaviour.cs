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

namespace ShoppingApp.Application.Configuration.UnitOfWork
{
    public class UnitOfWorkPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkPipelineBehaviour(IUnitOfWork shoppingAppContext)
        {
            _unitOfWork = shoppingAppContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                TResponse response = await next();
                if (IsCommand(request))
                {
                    await _unitOfWork.CommitAsync(cancellationToken);
                }
                return response;
            }
            catch (Exception e)
            {
                //TODO logs
                throw e;
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
