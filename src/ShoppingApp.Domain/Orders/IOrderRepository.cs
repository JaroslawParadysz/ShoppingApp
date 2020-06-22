using System;
using System.Threading.Tasks;

namespace ShoppingApp.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder(Guid orderId);
    }
}
