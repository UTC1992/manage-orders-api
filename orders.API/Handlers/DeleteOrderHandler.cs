using System;
using MediatR;
using orders.API.Commands;
using orders.Domain.Entities;
using orders.Domain.Repositories;

namespace orders.API.Handlers
{
	public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
	{
        private readonly IOrderRepository _repository;

        public DeleteOrderHandler(IOrderRepository repository)
		{
            this._repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return await this._repository.DeleteAsync(request.Id);
        }
    }
}

