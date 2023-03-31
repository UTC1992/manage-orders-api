using System;
namespace orders.Domain.Entities
{
	public class OrderProduct: Entity
	{
		public Guid OrderId { get; private set; }
		public Order Order { get; private set; }
		public Guid ProductId { get; private set; }
		public Product Product { get; private set; }
	}
}

