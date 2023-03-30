using System;
using orders.Infrastructure.Context.Entities;

namespace orders.Infrastructure.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T?> GetByIdAsync(Guid Id);
		Task<bool> InsertAsync(T entity);
		Task<bool> UpdateAsync(T entity);
		Task<bool> DeleteAsync(T entity);
	}
}

