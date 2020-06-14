using ShoppingApp.Domain.Products;
using System;

namespace ShoppingApp.Domain.Orders
{
    public class OrderProduct
    {
        public Guid OrderProductId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
