using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.SeedWork;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System;
using System.Threading;
using System.Threading.Tasks;

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
                if (typeof(ICommand).IsAssignableFrom(request.GetType()))
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
    }
}
