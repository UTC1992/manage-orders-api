using System;
namespace orders.Domain.Entities
{
	public class OrderDetail
	{
		public Guid OrderId { get; private set; }
		public Order Order { get; private set; }
		public Guid ProductId { get; private set; }
		public Product Product { get; private set; }

		public void SetOrderId(Guid Id)
		{
			this.OrderId = Id;
		}

        public void SetProductId(Guid productId)
        {
            this.ProductId = productId;
        }

		public void SeProduct(Product product)
		{
			this.Product = product;
		}

		public void SetOrder(Order order)
		{
			this.Order = order;
		}
    }
}

