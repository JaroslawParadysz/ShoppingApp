using ShoppingApp.Domain.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder(Guid orderId);
        Task<bool> AnyAsync();
        Task AddAsync(Order order);
    }
}
