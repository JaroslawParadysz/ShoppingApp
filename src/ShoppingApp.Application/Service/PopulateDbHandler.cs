using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.Orders;
using ShoppingApp.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Service
{
    public class PopulateDbHandler : ICommandHandler<PopulateDbCommand>
    {
        private readonly IOrderRepository _shoppingAppContext;
        private readonly IEnumerable<string> _productNames = new List<string>() { "Maslo", "Chleb" };
        private readonly string _orderName = "Zakupy";

        public PopulateDbHandler(IOrderRepository shoppingAppContext)
        {
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task<Unit> Handle(PopulateDbCommand request, CancellationToken cancellationToken)
        {
            Order o = _shoppingAppContext.Orders.FirstOrDefault();
            bool anyProductExists = await _shoppingAppContext.Products.AnyAsync();
            if (anyProductExists)
            {
                throw new InvalidOperationException();
            }

            List<Product> newProducts = CreateProducts();
            await _shoppingAppContext.Products.AddRangeAsync(newProducts);
            await _shoppingAppContext.SaveChangesAsync();

            Order order = Order.Create(_orderName);
            AddProductsToOrder(newProducts, order);

            await _shoppingAppContext.Orders.AddAsync(order);
            return Unit.Value;
        }

        private static void AddProductsToOrder(List<Product> newProducts, Order order)
        {
            foreach (Product product in newProducts)
            {
                order.AddProduct(product.ProductId, 2);
            }
        }

        private List<Product> CreateProducts()
        {
            List<Product> newProducts = new List<Product>();
            foreach (string name in _productNames)
            {
                newProducts.Add(Product.Create(name));
            }

            return newProducts;
        }
    }
}
