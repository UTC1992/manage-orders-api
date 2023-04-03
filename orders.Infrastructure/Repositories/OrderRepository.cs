using System;
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

        public async Task<IEnumerable<OrderDetail>> GetOrdersByProductIdAsync(Guid ProductId)
        {
            var entity = await this._context.Products.FindAsync(ProductId);
            if (entity is null)
                return Enumerable.Empty<OrderDetail>().ToList();

            var orders = (from od in this._context.OrderDetails
                           where od.ProductId == ProductId
                           select od).ToList();

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

        public async Task<bool> UpdateAsync(
            Order order,
            IEnumerable<Guid> productsId )
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));


            var orderDetailsToDelete = (from od in this._context.OrderDetails
                                        where od.OrderId == order.Id
                                        select od).ToList<OrderDetail>();

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
            }

            this._context.Orders.Update(order);
            await this._context.OrderDetails.AddRangeAsync(orderDetailToSave);
            await this._context.SaveChangesAsync();

            return true;
        }
    }
}

