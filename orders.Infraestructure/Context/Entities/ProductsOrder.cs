using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace orders.Infrastructure.Context.Entities
{
	[Table("ProductsOrder")]
	public class ProductsOrder : BaseEntity
	{
		[Column("Quantity")]
		public int Quantity { get; set; }

		[Column("ProductId")]
		public Guid ProductId { get; set; }
		public Product product { get; set; }

		[Column("OrderId")]
		public Guid OrderId { get; set; }
		public Order order { get; set; }
	}
}

