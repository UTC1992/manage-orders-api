using System;
using MediatR;
using orders.API.DTOs;
using orders.Domain.Entities;

namespace orders.API.Commands
{
	public record UpdateOrderCommand(string Address, IEnumerable<ProductDto> Products) : IRequest<OrderDto>;
}

