using System;
using orders.Domain.Entities;
using orders.Domain.Repositories;

namespace orders.Infrastructure.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsByOrderIdAsync(Guid OrderId)
        {
            var entity = await this._context.Orders.FindAsync(OrderId);
            if (entity is null)
                return Enumerable.Empty<Product>().ToList();

            var products = this._context.OrderDetails
                .Where(o => o.OrderId == OrderId)
                .Select(x => x.Product).ToList();

            return products;
        }
    }
}

