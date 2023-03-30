using System;
using Microsoft.EntityFrameworkCore;
using orders.Infrastructure.Context.Entities;
using orders.Infrastructure.Interfaces;

namespace orders.Infrastructure.Repositories
{
	public abstract class Repository<T> : IRepository<T> where T : BaseEntity
	{
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<T> _entities;

        public Repository(DatabaseContext databaseContext)
		{
            this._databaseContext = databaseContext;
            this._entities = databaseContext.Set<T>();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this._entities.Remove(entity);
            await this._databaseContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid Id)
        {
            return await this._entities.AsNoTracking()
                .SingleOrDefaultAsync( o => o.Id == Id);
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await this._entities.AddAsync(entity);
            await this._databaseContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this._entities.Update(entity);
            await this._databaseContext.SaveChangesAsync();
            return true;
        }
    }
}

