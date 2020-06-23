using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Products;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.SqlServer.Domain.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingAppContext _shoppingAppContext;

        public ProductRepository(ShoppingAppContext shoppingAppContext)
        {
            _shoppingAppContext = shoppingAppContext;
        }

        public async Task AddRangeAsync(List<ShoppingApp.Domain.Products.Product> newProducts)
        {
            await _shoppingAppContext.Products.AddRangeAsync(newProducts);
        }

        public async Task<bool> AnyAsync()
        {
            return await _shoppingAppContext.Products.AnyAsync();
        }
    }
}
