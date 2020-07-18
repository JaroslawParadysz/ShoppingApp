using MediatR;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Domain.Orders;
using ShoppingApp.Domain.Products;
using ShoppingApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Service
{
    public class PopulateDbHandler : ICommandHandler<PopulateDbCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEnumerable<string> _productNames = new List<string>() { "Maslo", "Chleb" };
        private readonly string _orderName = "Zakupy";

        public PopulateDbHandler(
            IOrderRepository shoppingAppContext,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = shoppingAppContext;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(PopulateDbCommand request, CancellationToken cancellationToken)
        {
            List<Product> newProducts = new List<Product>(); ;

            bool anyProductExists = await _productRepository.AnyAsync();
            if (anyProductExists)
            {
                throw new InvalidOperationException();
            }

            newProducts = CreateProducts();
            await _productRepository.AddRangeAsync(newProducts);

            Order order = Order.Create(_orderName);
            AddProductsToOrder(newProducts, order);

            await _orderRepository.AddAsync(order);
            return Unit.Value;
        }

        private static void AddProductsToOrder(List<Product> newProducts, Order order)
        {
            foreach (Product product in newProducts)
            {
                order.AddProduct(product, 2);
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
