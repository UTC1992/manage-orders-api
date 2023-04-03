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
    }
}

