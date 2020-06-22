using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.Orders;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.UpdateOrderDetails
{
    public class UpdaterderDetailsHandler : ICommandHandler<UpdateOrderDetailsCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdaterderDetailsHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrder(request.OrderId);
            order.UpdateTitle(request.Title);
            return Unit.Value;
        }
    }
}
