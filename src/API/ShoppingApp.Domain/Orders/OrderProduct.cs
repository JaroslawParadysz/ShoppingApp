using ShoppingApp.Domain.Products;
using System;

namespace ShoppingApp.Domain.Orders
{
    public class OrderProduct
    {
        public Guid OrderProductId { get; private set; }
        public int Quantity { get; private set; }
        public Order Order { get; private set; }
        public Product Product { get; private set; }
        public bool Purchased { get; private set; }

        private OrderProduct()
        {
        }

        internal void UpdatePurchased(bool purchased)
        {
            Purchased = purchased;
        }

        internal static OrderProduct Create(Order order, Product product, int quantity)
        {
            return new OrderProduct()
            {
                Order = order,
                Product = product,
                Quantity = quantity
            };
        }
    }
}
