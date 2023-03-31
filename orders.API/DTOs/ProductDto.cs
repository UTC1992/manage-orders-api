using System;
namespace orders.API.DTOs
{
	public class ProductDto
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}

