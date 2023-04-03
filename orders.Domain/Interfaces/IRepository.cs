using System;
using orders.Domain.Entities;
using orders.Domain.ValueObjects;

namespace orders.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> DeleteAsync(Guid Id);
    }
}

