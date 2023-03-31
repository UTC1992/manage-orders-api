using System;
using orders.Domain.ValueObjects;

namespace orders.Domain.Entities
{
  public class Product : Entity
  {
    public ProductName Name { get; private set; }
    public ProductPrice Price { get; private set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; private set; }

    public Product()
    {

    }

    public void SetName(ProductName name)
    {
      this.Name = name;
    }

    public void SetPrice(ProductPrice price)
    {
      this.Price = price;
    }
  }
}

