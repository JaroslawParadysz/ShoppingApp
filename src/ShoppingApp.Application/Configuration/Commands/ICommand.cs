using MediatR;

namespace ShoppingApp.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}
