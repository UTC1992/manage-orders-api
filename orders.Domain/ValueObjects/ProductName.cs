using System;
namespace orders.Domain.ValueObjects
{
	public record class ProductName
	{
		public string Value { get; init; }

		public ProductName(string value)
		{
			this.Value = value;
		}

		public static ProductName Create(string value)
		{
			return new ProductName(value);
		}
	}
}

