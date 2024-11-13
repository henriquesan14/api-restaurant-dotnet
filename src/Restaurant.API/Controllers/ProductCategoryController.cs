using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.ProductCategoryCommands.CreateCategory;
using Restaurant.Application.Commands.ProductCategoryCommands.DeleteCategory;
using Restaurant.Application.Commands.ProductCategoryCommands.UpdateCategory;
using Restaurant.Application.Queries.CategoryQueries.GetByCategoryType;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCategoryCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            if(id == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCategoryCommand(id);
            var result = await _mediator.Send(command);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
