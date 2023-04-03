using System;
using Microsoft.EntityFrameworkCore;
using orders.Domain.Entities;
using orders.Domain.Interfaces;
using orders.Domain.ValueObjects;

namespace orders.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _entity;

        protected Repository(DatabaseContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await _entity.FindAsync(Id);
            if (entity is null)
                return false;

            _entity.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

