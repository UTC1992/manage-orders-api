using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using orders.API.Commands.Product;
using orders.API.Queries;
using orders.API.Queries.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace orders.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await this._mediator.Send(new GetAllProductsQuery());
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all products.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while getting all products. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand command)
        {
            try
            {
                var product = await this._mediator.Send(command);
                return Ok(product);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding product.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "An error occurred while adding product. Please try again later.");
            }
        }

    }
}

