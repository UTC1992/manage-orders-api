using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using orders.API.Commands;
using orders.API.Queries;

namespace orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderCommand command)
        {
            var order = await this._mediator.Send(command);
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await this._mediator.Send(command);
            if(!response)
            {
                return NotFound();
            }

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await this._mediator.Send(new DeleteOrderCommand(id));
            return NoContent();
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByOrderId(Guid id)
        {
            var query = new GetProductsByOrderIdQuery(id);
            var products = await this._mediator.Send(query);
            return Ok(products);
        }

    }
}

