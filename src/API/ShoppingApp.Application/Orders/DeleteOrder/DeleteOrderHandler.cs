using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.Orders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.DeleteOrder
{
    public class DeleteOrderHandler : ICommandHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteOrder(command.OrderId);
            return Unit.Value;
        }
    }
}
