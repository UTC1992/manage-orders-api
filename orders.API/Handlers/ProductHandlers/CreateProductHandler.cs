using System;
using MediatR;
using orders.API.Commands.Product;
using orders.API.DTOs;
using orders.Domain.Entities;
using orders.Domain.Repositories;
using orders.Domain.ValueObjects;

namespace orders.API.Handlers.ProductHandlers
{
	public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
	{
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            this._repository = repository;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.SetName(ProductName.Create(request.Name));
            product.SetPrice(ProductPrice.Create(request.Price));

            var productSaved = await this._repository.InsertAsync(product);

            return new ProductDto
            {
                Id = productSaved.Id,
                Name = productSaved.Name.Value,
                Price = productSaved.Price.Value
            };
        }
    }
}

