using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using orders_api.ApplicationServices;
using orders_api.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace orders_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices orderServices;

        public OrderController(OrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderCommand createOrderCommand)
        {
            await this.orderServices.HandleCommand(createOrderCommand);
            return Ok(createOrderCommand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetOrder(Guid id)
        {
            var response = await this.orderServices.GetOrder(id);
            return Ok(response);
        }
    }
}

