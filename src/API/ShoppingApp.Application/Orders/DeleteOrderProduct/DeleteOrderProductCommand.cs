using ShoppingApp.Application.Configuration.Commands;
using System;

namespace ShoppingApp.Application.Orders.DeleteOrderProduct
{
    public class DeleteOrderProductCommand : ICommand
    {
        public DeleteOrderProductCommand(Guid orderId, Guid orderProductId)
        {
            OrderId = orderId;
            OrderProductId = orderProductId;
        }

        public Guid OrderId { get; private set; }
        public Guid OrderProductId { get; private set; }
    }
}
