﻿using System;
using orders.Domain.Entities;
using orders.Domain.Interfaces;
using orders.Domain.ValueObjects;

namespace orders.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> InsertAsync(Order order, IEnumerable<Guid> productsId);
        Task<Order> UpdateAsync(Order order, IEnumerable<Guid> productsId);
        Task<IEnumerable<Order>> GetOrdersByProductIdAsync(Guid ProductId, int limit, int offset);
    }
}

