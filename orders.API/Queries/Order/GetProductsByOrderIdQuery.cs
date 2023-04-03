using System;
using MediatR;
using orders.API.DTOs;

namespace orders.API.Queries
{
	public record GetProductsByOrderIdQuery(Guid OrderId) : IRequest<IEnumerable<ProductDto>>;
}

