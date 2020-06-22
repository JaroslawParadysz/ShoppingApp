using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using ShoppingApp.Application.Configuration.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using ShoppingApp.Application.SeedWork;

namespace ShoppingApp.Application.Configuration.UnitOfWork
{
    public class CQRSPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ICommandProcessor<TRequest, TResponse> _commandProcessor;
        public CQRSPipelineBehaviour(
            ICommandProcessor<TRequest, TResponse> commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                bool isCommand = IsCommand(request);
                if (isCommand)
                {
                    return await _commandProcessor.ProcessCommand(request, cancellationToken, next);
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

        private static bool IsCommand(TRequest request)
        {
            return request.GetType().GetInterfaces()
                .Any(x =>
                    x is ICommand
                    || (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICommand<>)));
        }
    }
}
