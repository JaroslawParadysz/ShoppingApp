using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.Orders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.CreateOrder
{
    public class CreateNewOrderHandler : ICommandHandler<CreateNewOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateNewOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.Create(request.OrderName);
            await _orderRepository.AddAsync(order);
            return Unit.Value;
        }
    }
}
