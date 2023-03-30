using System;
namespace orders.Domain.ValueObjects
{
	public class OrderId
	{
		public Guid Value { get; init; }

		internal OrderId(Guid value)
		{
			this.Value = value;
		}

		public static OrderId create(Guid value)
		{
			return new OrderId(value);
		}

		public static implicit operator Guid(OrderId orderId)
		{
			return orderId.Value;
		}
	}
}

