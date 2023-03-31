using System;
using MediatR;
using orders.API.DTOs;

namespace orders.API.Queries
{
	public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDto>;
}

