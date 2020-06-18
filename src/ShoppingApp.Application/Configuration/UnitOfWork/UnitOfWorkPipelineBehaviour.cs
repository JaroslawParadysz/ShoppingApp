using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Configuration.UnitOfWork
{
    public class UnitOfWorkPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Trace.WriteLine("before");
            TResponse response = await next();
            Trace.WriteLine("after");
            return response;
        }
    }
}
