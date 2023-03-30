using System;
using orders.Domain.Entities;
using orders.Domain.ValueObjects;

namespace orders.Domain.Repositories
{
  public interface IOrderRepository
  {
    Task<Order> GetOrdersById(OrderId Id);
    Task AddOrder(Order order);
  }
}

