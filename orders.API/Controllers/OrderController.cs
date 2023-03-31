using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using orders.API.Commands;

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

        //[HttpGet("{id}")]
        //public async Task<IActionResult>GetOrder(Guid id)
        //{
        //    var response = await this.orderServices.GetOrder(id);
        //    return Ok(response);
        //}
    }
}

