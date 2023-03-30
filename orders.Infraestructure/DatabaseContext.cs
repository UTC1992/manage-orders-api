using Microsoft.EntityFrameworkCore;
using orders.Domain.Entities;

namespace orders.Infrastructure
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Order>(o =>
      {
        o.HasKey(x => x.Id);
      });

      modelBuilder.Entity<Order>().OwnsOne(o => o.Address, conf =>
      {
        conf.Property(x => x.Value).HasColumnName("Address");
      });



      base.OnModelCreating(modelBuilder);
    }
  }

}

