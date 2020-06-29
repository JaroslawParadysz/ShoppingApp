using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.SeedWork;
using ShoppingApp.Domain.SeedWork;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.SqlServer.Application
{
    public class CommandProcessor<TRequest, TResponse> : ICommandProcessor<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingAppContext _shoppingAppContext;

        public CommandProcessor(IUnitOfWork unitOfWork, ShoppingAppContext shoppingAppContext)
        {
            _unitOfWork = unitOfWork;
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task<TResponse> ProcessCommand(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var strategy = _shoppingAppContext.Database.CreateExecutionStrategy();
            TResponse response = await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _shoppingAppContext.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    response = await next();
                    await _unitOfWork.CommitAsync();
                    await transaction.CommitAsync();
                    return response;
                }
            }
            );

            return response;
        }
    }
}
