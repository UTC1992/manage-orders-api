using System;
using MediatR;
using orders.API.DTOs;
using orders.API.Queries;
using orders.Domain.Repositories;

namespace orders.API.Handlers.OrderHandlers
{
	public class GetProductsByOrderIdHandler
        : IRequestHandler<GetProductsByOrderIdQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public GetProductsByOrderIdHandler(IProductRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var result = await this._repository.GetProductsByOrderIdAsync(request.OrderId);

            var products = new List<ProductDto>();
            foreach(var product in result)
            {
                var item = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name.Value,
                    Price = product.Price.Value,
                };
                products.Add(item);
            }

            return products;
        }
    }
}

