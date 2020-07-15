using System;

namespace ShoppingApp.Application.Orders.GetOrderDetails
{
    public class OrderProductDto
    {
        public Guid OrderProductId { get; set; }
        public string Name { get; set; }
        public bool Purchased { get; set; }
        public int Quantity { get; set; }
    }
}
