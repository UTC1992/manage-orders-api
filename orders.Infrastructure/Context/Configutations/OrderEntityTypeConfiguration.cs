using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orders.Domain.Entities;

namespace orders.Infrastructure
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(o => o.Address, conf =>
            {
                conf.Property(x => x.Value).HasColumnName("Address")
                .HasColumnType("varchar(100)");
            });
        }
    }
}