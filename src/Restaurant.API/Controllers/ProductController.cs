using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.ProductCommands.CreateProduct;
using Restaurant.Application.Commands.ProductCommands.RemoveProduct;
using Restaurant.Application.Commands.ProductCommands.UpdateProduct;
using Restaurant.Application.Queries.ProductQueries.GetAllProducts;
using Restaurant.Application.Queries.ProductQueries.GetProduct;
using Restaurant.Application.ViewModels.Page;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter)
        {
            var query = new GetAllProductsQuery(pageFilter);
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductQuery(id);
            var product = await _mediator.Send(query);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediator.Send(command);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
