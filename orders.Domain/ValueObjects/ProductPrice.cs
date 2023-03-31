using System;
namespace orders.Domain.ValueObjects
{
	public class ProductPrice
	{
		public decimal Value { get; init; }

		public ProductPrice(decimal value)
		{
			this.Value = value;
		}

		public static ProductPrice Create(decimal value)
		{
			return new ProductPrice(value);
		}
	}
}

