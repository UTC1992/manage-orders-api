using System;
using orders.Domain.Entities;
using orders.Domain.ValueObjects;

namespace orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(EntityId id);
        Task<bool> InsertAsync(Order order);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(Order order);
    }
}

