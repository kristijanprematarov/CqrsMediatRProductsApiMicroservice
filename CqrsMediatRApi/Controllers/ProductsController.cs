using CqrsMediatRApi.Commands;
using CqrsMediatRApi.Models;
using CqrsMediatRApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _mediator.Send(new AddProductCommand(product));

            return StatusCode(201);
        }
    }
}
