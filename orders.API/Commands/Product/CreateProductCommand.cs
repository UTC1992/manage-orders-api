using System;
using MediatR;
using orders.API.DTOs;

namespace orders.API.Commands.Product
{
    public record CreateProductCommand(string Name, decimal Price) : IRequest<ProductDto>;
}

