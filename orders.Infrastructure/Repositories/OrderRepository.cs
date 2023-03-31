using System;
using Microsoft.EntityFrameworkCore;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;
using orders.Infrastructure.Repositories;

namespace orders.Infrastructure
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext dbContext): base(dbContext) 
        {

        }
    }
}

