using System;
using MediatR;
using orders.API.DTOs;
using orders.Domain.Entities;

namespace orders.API.Commands
{
    public record UpdateOrderCommand(
        Guid Id,
        string Address,
        IEnumerable<Guid> ProductsId
    ) : IRequest<bool>;
}

