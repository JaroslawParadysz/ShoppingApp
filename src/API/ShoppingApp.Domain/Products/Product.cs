using ShoppingApp.Domain.SeedWork;
using System;

namespace ShoppingApp.Domain.Products
{
    public class Product : IAggregateRoot
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }

        private Product()
        {                
        }

        public static Product Create(string name)
        {
            return new Product() { Name = name };
        }
    }
}
