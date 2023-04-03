using System;
using MediatR;
using orders.API.DTOs;
using orders.API.Queries;
using orders.Domain.Repositories;

namespace orders.API.Handlers.OrderHandlers
{
	public class GetOrdersByProductIdHandler
        : IRequestHandler<GetOrdersByProductIdQuery, IEnumerable<OrderDto>>
	{
        private readonly IOrderRepository _repository;

        public GetOrdersByProductIdHandler(IOrderRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByProductIdQuery request, CancellationToken cancellationToken)
        {
            var result = await this._repository.GetOrdersByProductIdAsync(request.ProductId);

            var orders = new List<OrderDto>();
            foreach(var orderDetail in result)
            {
                var item = new OrderDto
                {
                    Id = orderDetail.Order.Id,
                    Address = orderDetail.Order.Address.Value
                };
                orders.Add(item);
            }

            return orders;
        }
    }
}

