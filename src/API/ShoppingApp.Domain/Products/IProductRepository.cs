using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Products
{
    public interface IProductRepository
    {
        Task<bool> AnyAsync();
        Task AddRangeAsync(List<Product> newProducts);
        Task<Product> GetProduct(Guid productId);
    }
}
