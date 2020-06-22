using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Orders;
using ShoppingApp.Infrastructure.SqlServer.Database;
using System;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.SqlServer.Domain.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingAppContext _shoppingAppContext;

        public OrderRepository(ShoppingAppContext shoppingAppContext)
        {
            _shoppingAppContext = shoppingAppContext ?? throw new ArgumentNullException(nameof(shoppingAppContext)); ;
        }

        public async Task<ShoppingApp.Domain.Orders.Order> GetOrder(Guid orderId)
        {
            return await _shoppingAppContext.Orders
                .SingleOrDefaultAsync(x => x.OrderId == orderId);
        }
    }
}
