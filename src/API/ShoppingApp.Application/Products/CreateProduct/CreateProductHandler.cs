using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Products.CreateProduct
{
    public class CreateProductHandler : ICommandHandler<CreateProductCommand>
    {
        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
