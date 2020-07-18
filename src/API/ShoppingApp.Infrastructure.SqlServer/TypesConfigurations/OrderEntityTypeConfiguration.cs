using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Domain.Orders;

namespace ShoppingApp.Infrastructure.SqlServer.TypesConfigurations
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        private readonly string orderProducts = "_orderProducts";
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(b => b.OrderId);

            builder.OwnsMany<OrderProduct>(orderProducts, x =>
            {
                x.ToTable("OrderProducts");
                x.HasKey(y => y.OrderProductId);
                x.WithOwner(y => y.Order);
                x.HasOne(x => x.Product)
                    .WithMany();
            });
        }
    }
}
