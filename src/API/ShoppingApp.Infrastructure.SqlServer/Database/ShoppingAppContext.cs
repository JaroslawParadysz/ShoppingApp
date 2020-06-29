using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Orders;
using ShoppingApp.Domain.Products;

namespace ShoppingApp.Infrastructure.SqlServer.Database
{
    public class ShoppingAppContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShoppingAppContext(DbContextOptions<ShoppingAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingAppContext).Assembly);
        }
    }
}
