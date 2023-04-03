using System;
using MediatR;
using orders.API.Commands;
using orders.API.DTOs;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders.API.Handlers.OrderHandlers
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderHandler(IOrderRepository repository)
        {
            this._repository = repository;
        }

        public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order();
            order.SetId(request.Id);
            order.SetAddress(OrderAddress.Create(request.Address));

            var orderUpdated = await this._repository.UpdateAsync(order, request.ProductsId);
            return new OrderDto
            {
                Id = orderUpdated.Id,
                Address = orderUpdated.Address.Value
            };
        }
    }
}

