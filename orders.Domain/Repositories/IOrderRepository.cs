using System;
using orders.Domain.Entities;
using orders.Domain.Interfaces;
using orders.Domain.ValueObjects;

namespace orders.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> InsertAsync(Order order, IEnumerable<Guid> productsId);
        Task<bool> UpdateAsync(Order order, IEnumerable<Guid> productsId);
    }
}

