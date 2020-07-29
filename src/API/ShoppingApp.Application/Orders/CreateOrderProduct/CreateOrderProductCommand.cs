using ShoppingApp.Application.Configuration.Commands;
using System;

namespace ShoppingApp.Application.Orders.CreateOrderProduct
{
    public class CreateOrderProductCommand : ICommand<Guid>
    {
        public CreateOrderProductCommand(Guid orderId, Guid productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
    }
}
