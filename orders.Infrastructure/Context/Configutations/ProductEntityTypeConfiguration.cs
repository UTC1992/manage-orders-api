using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using orders.Domain.Entities;

namespace orders.Infrastructure
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(p => p.Name, conf =>
            {
                conf.Property(x => x.Value).HasColumnName("Name")
                .HasColumnType("varchar(45)");
            });
            builder.OwnsOne(p => p.Price, conf =>
            {
                conf.Property(x => x.Value).HasColumnName("Price")
                .HasColumnType("decimal(5,2)");
            });
        }
    }
}