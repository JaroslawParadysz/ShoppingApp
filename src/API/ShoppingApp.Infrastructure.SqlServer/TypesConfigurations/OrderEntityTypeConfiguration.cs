using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Domain.Orders;

namespace ShoppingApp.Infrastructure.SqlServer.TypesConfigurations
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public static readonly string OrderProducts = "_orderProducts";
        public static readonly string Product = "Product";
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(b => b.OrderId);

            builder.OwnsMany<OrderProduct>(OrderProducts, x =>
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
