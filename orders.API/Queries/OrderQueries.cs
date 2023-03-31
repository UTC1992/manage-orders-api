using System;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders_api.Queries
{
	public class OrderQueries
	{
        private readonly IOrderRepository orderRepository;

        public OrderQueries(IOrderRepository orderRepository)
		{
            this.orderRepository = orderRepository;
        }

        public async Task<Order?> GetOrderIdAsync(Guid id)
        {
            return await this.orderRepository.GetByIdAsync(EntityId.create(id));
        }
	}
}

