using System;
using MediatR;
using orders.API.DTOs;

namespace orders.API.Queries.Product
{
	public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;
}

