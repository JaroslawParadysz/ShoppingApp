using ShoppingApp.Application.Configuration.Commands;
using System;

namespace ShoppingApp.Application.Orders.UpdateOrderProduct
{
    public class UpdateOrderProductCommand : ICommand
    {
        public UpdateOrderProductCommand(
            Guid orderId,
            Guid orderProductId,
            bool purchased)
        {
            OrderId = orderId;
            OrderProductId = orderProductId;
            Purchased = purchased;
        }

        public Guid OrderId { get; }
        public Guid OrderProductId { get; }
        public bool Purchased { get; }
    }
}
