using ShoppingApp.Domain.Products;
using System;

namespace ShoppingApp.Domain.Orders
{
    public class OrderProduct
    {
        public Guid OrderProductId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Order Order { get; private set; }
        public bool Purchased { get; private set; }

        private OrderProduct()
        {
        }

        internal static OrderProduct Create(Order order, Guid productId, int quantity)
        {
            return new OrderProduct()
            {
                Order = order,
                ProductId = productId,
                Quantity = quantity
            };
        }
    }
}
