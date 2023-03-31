using System;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;
using orders_api.Commands;
using orders_api.Queries;

namespace orders_api.ApplicationServices
{
	public class OrderServices
	{
		private readonly IOrderRepository repository;
        private readonly OrderQueries orderQueries;

        public OrderServices(IOrderRepository repository, OrderQueries orderQueries)
		{
			this.repository = repository;
            this.orderQueries = orderQueries;
        }

		public async Task HandleCommand(CreateOrderCommand createOrder)
		{
			var order = new Order();
            order.SetAddress(OrderAddress.Create(createOrder.Address));

            await this.repository.InsertAsync(order); 
		}

		public async Task<Order?> GetOrder(Guid id)
		{
			return await this.orderQueries.GetOrderIdAsync(id);
		}
	}
}

