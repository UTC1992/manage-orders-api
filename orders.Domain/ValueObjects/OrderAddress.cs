using System;
namespace orders.Domain.ValueObjects
{
	public record OrderAddress
	{
		public string Value { get; init; }

		internal OrderAddress(string value)
		{
			this.Value = value;
		}

		public static OrderAddress Create(string value)
		{
			return new OrderAddress(value);
		}
	}
}

