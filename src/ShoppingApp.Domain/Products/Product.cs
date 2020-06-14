using ShoppingApp.Domain.SeedWork;
using System;

namespace ShoppingApp.Domain.Products
{
    public class Product : IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
