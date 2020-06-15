using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.Infrastructure.SqlServer
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
                x.HasKey(y => y.OrderProductId);
                x.WithOwner(y => y.Order).HasForeignKey(x => x.OrderId);
                x.HasOne(y => y.Product);
            });
        }
    }
}
