using System;
using MediatR;
using orders.API.DTOs;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders.API.Queries
{
	public record GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>;
}

