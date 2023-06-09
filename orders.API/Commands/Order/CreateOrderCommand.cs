﻿using System;
using MediatR;
using orders.API.DTOs;

namespace orders.API.Commands
{
	public record CreateOrderCommand(string Address, IEnumerable<Guid> ProductsId) : IRequest<OrderDto>;
}

