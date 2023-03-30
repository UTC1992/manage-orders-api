using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace orders.Infrastructure.Context.Entities
{
	[Table("Order")]
	public class Order : BaseEntity
	{
		[Column("Address")]
		public string Address { get; set; } = string.Empty;
		[Column("ShippingDate")]
		public DateOnly ShippingDate { get; set; }

        public ICollection<Product> products { get; set; }
		public List<ProductsOrder> productsOrders { get; set; }
	}
}

