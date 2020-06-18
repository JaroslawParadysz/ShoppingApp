using MediatR;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Configuration.UnitOfWork
{
    public class UnitOfWorkPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ShoppingAppContext _shoppingAppContext;
        public UnitOfWorkPipelineBehaviour(ShoppingAppContext shoppingAppContext)
        {
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                TResponse response = await next();
                await _shoppingAppContext.SaveChangesAsync();
                return response;
            }
            catch (Exception e)
            {
                //TODO logs
                throw e;
            }            
        }
    }
}
