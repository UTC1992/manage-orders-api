using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orders.Domain.Entities;

namespace orders.Infrastructure
{
    internal class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(op => new { op.OrderId, op.ProductId });
            builder.HasOne(op => op.Order)
                .WithMany(op => op.OrderDetails)
                .HasForeignKey(op => op.OrderId);
            builder.HasOne(op => op.Product)
                .WithMany(op => op.OrderDetails)
                .HasForeignKey(op => op.ProductId);
        }
    }
}