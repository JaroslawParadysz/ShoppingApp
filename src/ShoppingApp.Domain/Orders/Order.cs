using ShoppingApp.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace ShoppingApp.Domain.Orders
{
    public class Order : IAggregateRoot
    {
        public Guid OrderId { get; set; }
        public string Title { get; set; }
        private List<OrderProduct> _orderProducts;
    }
}
