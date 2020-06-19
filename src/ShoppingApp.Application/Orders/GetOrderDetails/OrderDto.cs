using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.Application.Orders.GetOrderDetails
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string Title { get; set; }
    }
}
