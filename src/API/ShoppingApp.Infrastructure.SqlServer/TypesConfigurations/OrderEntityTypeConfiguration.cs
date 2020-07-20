using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingApp.Domain.Orders;

namespace ShoppingApp.Infrastructure.SqlServer.TypesConfigurations
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(b => b.OrderId);

            builder.OwnsMany<OrderProduct>(x => x.OrderProducts, x =>
                {
                    x.ToTable("OrderProducts");
                    x.HasKey(y => y.OrderProductId);
                    x.WithOwner(y => y.Order);
                    x.HasOne(x => x.Product)
                        .WithMany();

                    x.OwnedEntityType.FindNavigation(nameof(OrderProduct.Product)).SetIsEagerLoaded(true);
                }
            );
            builder.Metadata.FindNavigation(nameof(Order.OrderProducts))
                .SetPropertyAccessMode(PropertyAccessMode.Field);            
        }
    }
}
