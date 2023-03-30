using System;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders.Infrastructure
{
  public class OrderRepository : IOrderRepository
  {
    DatabaseContext db;

    public OrderRepository(DatabaseContext db_)
    {
      this.db = db_;
    }

    async Task IOrderRepository.AddOrder(Order order)
    {
      await this.db.AddAsync(order);
      await this.db.SaveChangesAsync();
    }

    async Task<Order> IOrderRepository.GetOrdersById(OrderId Id)
    {
      return await this.db.Orders.FindAsync((Guid)Id);
    }
  }
}

