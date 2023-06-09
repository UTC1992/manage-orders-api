﻿using System;
using Microsoft.EntityFrameworkCore;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;
using orders.Infrastructure.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace orders.Infrastructure
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DatabaseContext _context;

        public OrderRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByProductIdAsync(Guid ProductId, int limit, int offset)
        {
            var entity = await this._context.Products.FindAsync(ProductId);
            if (entity is null)
                return Enumerable.Empty<Order>().ToList();

            var orders = this._context.OrderDetails
                .Where(od => od.ProductId == ProductId)
                .Select(od => od.Order)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return orders;
        }

        public async Task<Order> InsertAsync(
            Order order, IEnumerable<Guid> productsId)
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            await this._context.Orders.AddAsync(order);
            await this._context.SaveChangesAsync();

            var orderWithDetails = this._context.Orders
                .Include(o => o.OrderDetails)
                .Where(x => x.Id == order.Id)
                .First();

            foreach (Guid id in productsId)
            {
                var orderDetail = new OrderDetail();
                orderDetail.SetOrderId(order.Id);
                orderDetail.SetProductId(id);

                orderWithDetails.OrderDetails.Add(orderDetail);
                
            }

            await this._context.SaveChangesAsync();

            return orderWithDetails;
        }

        public async Task<Order> UpdateAsync(
            Order order,
            IEnumerable<Guid> productsId )
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));


            var orderDetailsToDelete = this._context.OrderDetails
                .Where(od => od.OrderId == order.Id)
                .Select(od => od).ToList();

            if (orderDetailsToDelete.Count > 0)
            {
                this._context.OrderDetails.RemoveRange(orderDetailsToDelete);
                await this._context.SaveChangesAsync();
            }

            var orderDetailToSave = new List<OrderDetail>();
            foreach (Guid id in productsId)
            {
                var orderDetail = new OrderDetail();
                orderDetail.SetOrderId(order.Id);
                orderDetail.SetProductId(id);

                orderDetailToSave.Add(orderDetail);
                order.SetOrderDetails(orderDetail);
            }

            this._context.Orders.Update(order);
            await this._context.OrderDetails.AddRangeAsync(orderDetailToSave);
            await this._context.SaveChangesAsync();

            return order;
        }
    }
}

