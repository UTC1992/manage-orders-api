using System;
using MediatR;
using orders.API.DTOs;
using orders.API.Queries.Product;
using orders.Domain.Repositories;

namespace orders.API.Handlers.ProductHandlers
{
	public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
	{
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var resultProducts = await this._repository.GetAllAsync();
            var products = new List<ProductDto>();

            foreach( var product in resultProducts)
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

