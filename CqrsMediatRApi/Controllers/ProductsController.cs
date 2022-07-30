using CqrsMediatRApi.Commands;
using CqrsMediatRApi.Models;
using CqrsMediatRApi.Notifications;
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

        [HttpGet("{id:int}", Name = nameof(GetProductById))]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);
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
            var createdProduct = await _mediator.Send(new AddProductCommand(product));

            await _mediator.Publish(new ProductAddedNotification(Product: createdProduct));

            return CreatedAtRoute(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }
    }
}
