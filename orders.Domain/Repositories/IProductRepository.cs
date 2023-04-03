using System;
using orders.Domain.Entities;
using orders.Domain.Interfaces;

namespace orders.Domain.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
    }
}

