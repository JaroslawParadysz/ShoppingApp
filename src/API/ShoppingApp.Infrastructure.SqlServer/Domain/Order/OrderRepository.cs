using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Orders;
using ShoppingApp.Infrastructure.SqlServer.Database;
using ShoppingApp.Infrastructure.SqlServer.SeedWork;
using ShoppingApp.Infrastructure.SqlServer.TypesConfigurations;
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

        public async Task AddAsync(ShoppingApp.Domain.Orders.Order order)
        {
            await _shoppingAppContext.Orders.AddAsync(order);
        }

        public async Task<bool> AnyAsync()
        {
            return await _shoppingAppContext.Orders.AnyAsync();
        }

        public async Task<ShoppingApp.Domain.Orders.Order> GetOrder(Guid orderId)
        {
            return await _shoppingAppContext.Orders
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .SingleOrDefaultAsync(x => x.OrderId == orderId);
        }
    }
}
