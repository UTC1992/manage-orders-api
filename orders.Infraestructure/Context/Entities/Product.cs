using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace orders.Infrastructure.Context.Entities
{
	[Table("Product")]
	public class Product : BaseEntity
	{
		[Column("Name")]
		public string Name { get; set; } = string.Empty;
		[Column("Description")]
		public string Description { get; set; } = string.Empty;
		[Column("Price")]
		public decimal Price { get; set; }

		public ICollection<Order> Orders { get; set; }
		public List<ProductsOrder> productsOrders { get; set; }

	}
}

