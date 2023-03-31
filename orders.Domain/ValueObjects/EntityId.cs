using System;
namespace orders.Domain.ValueObjects
{
	public record class EntityId
	{
		public Guid Value { get; init; }

		internal EntityId(Guid value)
		{
			this.Value = value;
		}

		public static EntityId create(Guid value)
		{
			return new EntityId(value);
		}

		public static implicit operator Guid(EntityId orderId)
		{
			return orderId.Value;
		}
	}
}

