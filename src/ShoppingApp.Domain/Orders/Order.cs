using ShoppingApp.Domain.SeedWork;
using System;

namespace ShoppingApp.Domain.Orders
{
    public class Order : IAggregateRoot
    {
        public Guid OrderId { get; set; }
        public string Title { get; set; }
    }
}
