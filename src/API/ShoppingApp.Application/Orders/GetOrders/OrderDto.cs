using System;

namespace ShoppingApp.Application.Orders.GetOrders
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string Title { get; set; }
    }
}
