﻿using System;
using MediatR;
using orders.API.Commands;
using orders.API.DTOs;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders.API.Handlers.OrderHandlers
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

            var orderSaved = await this._repository.InsertAsync(order, request.ProductsId);
            return new OrderDto
            {
                Id = orderSaved.Id,
                Address = orderSaved.Address.Value
            };
        }

    }
}

