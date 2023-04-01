using System;
using orders.Domain.ValueObjects;

namespace orders.Domain.Entities
{
    public class Order : BaseEntity
    {
        public OrderAddress Address { get; private set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; private set; }

        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public void SetAddress(OrderAddress address)
        {
            Address = address;
        }
    }
}

