using System;
using Microsoft.EntityFrameworkCore;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _db;

        public OrderRepository(DatabaseContext db)
        {
            this._db = db;
        }

        public async Task<bool> DeleteAsync(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            this._db.Orders.Remove(order);
            await this._db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await this._db.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(EntityId Id)
        {
            //return await this._db.Orders.AsNoTracking()
            //    .SingleOrDefaultAsync(o => o.Id == (Guid)id);
            return await this._db.Orders.FindAsync((Guid)Id);
        }

        public async Task<bool> InsertAsync(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            await this._db.Orders.AddAsync(order);
            await this._db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            this._db.Orders.Update(order);
            await this._db.SaveChangesAsync();
            return true;
        }
    }
}

