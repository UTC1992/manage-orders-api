using System;
using orders.Domain.Entities;

namespace orders.API.DTOs
{
	public class OrderDto
	{
		public Guid Id { get; set; }
		public string Address { get; set; } = string.Empty;
		public IEnumerable<Guid> ProductsId { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

    }
}

