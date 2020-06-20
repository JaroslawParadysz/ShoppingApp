using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.Orders;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.UpdateOrderDetails
{
    public class UpdaterderDetailsHandler : ICommandHandler<UpdateOrderDetailsCommand, Unit>
    {
        private readonly ShoppingAppContext _shoppingAppContext;

        public UpdaterderDetailsHandler(ShoppingAppContext shoppingAppContext)
        {
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task<Unit> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            Order order = await _shoppingAppContext.Orders
                .SingleOrDefaultAsync(x => x.OrderId == request.OrderId);
            order.UpdateTitle(request.Title);
            return Unit.Value;
        }
    }
}
