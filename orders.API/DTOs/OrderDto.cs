using System;
using orders.Domain.Entities;

namespace orders.API.DTOs
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public string Address { get; set; } = string.Empty;
		public IEnumerable<Product> Products { get; set; }
	}
}

