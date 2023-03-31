using System;
using MediatR;

namespace orders.API.Commands
{
	public record DeleteOrderCommand(Guid Id) : IRequest<bool>;
}

