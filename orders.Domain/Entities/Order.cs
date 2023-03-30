using System;
using orders.Domain.ValueObjects;

namespace orders.Domain.Entities
{
	public class Order
	{
		public Guid Id { get; init; }
		public OrderAddress Address { get; private set; }

		public Order(Guid id)
		{
			this.Id = id;
		}

		public void SetAddress(OrderAddress address)
		{
			Address = address;
		}
	}
}

