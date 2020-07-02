using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Orders.UpdateOrderProduct
{
    public class UpdateOrderProductHandler : ICommandHandler<UpdateOrderProductCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderProductHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderProductCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrder(request.OrderId);
            order.UpdateProduct(request.OrderProductId, request.Purchased);
            return Unit.Task.Result;
        }
    }
}
