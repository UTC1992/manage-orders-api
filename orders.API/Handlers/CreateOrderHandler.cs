using System;
using MediatR;
using orders.API.Commands;
using orders.API.DTOs;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders.API.Handlers
{
	public class CreateOrderHandler
        : IRequestHandler<CreateOrderCommand, OrderDto>
	{
        private readonly IOrderRepository _repository;

        public CreateOrderHandler(IOrderRepository repository)
		{
            this._repository = repository;
		}

        public async Task<OrderDto> Handle(
            CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order();
            order.SetAddress(OrderAddress.Create(request.Address));
            await this._repository.InsertAsync(order, request.ProductsId);

            return new OrderDto
            {
                Id = order.Id,
                Address = order.Address.Value,
            };
        }

    }
}

