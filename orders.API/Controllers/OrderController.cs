using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using orders.API.Commands;
using orders.API.Queries;

namespace orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByOrderId(Guid id)
        {
            try
            {
                var query = new GetProductsByOrderIdQuery(id);
                var products = await this._mediator.Send(query);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting products by orderId.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while getting products by orderId. Please try again later.");
            }
        }

        [HttpGet("Product/{id}/orders/{limit}/{offset}")]
        public async Task<IActionResult> GetOrdersByProductId(Guid id, int limit, int offset)
        {
            try
            {
                var query = new GetOrdersByProductIdQuery(id, limit, offset);
                var orders = await this._mediator.Send(query);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting orders by productId.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while getting orders by productId. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderCommand command)
        {
            try
            {
                var order = await this._mediator.Send(command);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the order.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while adding the order. Please try again later.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return BadRequest();
                }

                var response = await this._mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the order.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while updating the order. Please try again later.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            try
            {
                await this._mediator.Send(new DeleteOrderCommand(id));
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the order.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while deleting the order. Please try again later.");
            }
        }

    }
}

