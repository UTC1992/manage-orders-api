using System;
using orders.Domain.ValueObjects;

namespace orders.Domain.Entities
{
  public class Order : BaseEntity
  {
    public OrderAddress Address { get; private set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; private set; }

    public Order()
    {
      this.OrderProducts = new List<OrderProduct>();
    }

    public void SetAddress(OrderAddress address)
    {
      Address = address;
    }
  }
}

