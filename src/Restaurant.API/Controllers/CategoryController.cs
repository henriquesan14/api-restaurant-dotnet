using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.CategoryCommands.CreateCategory;
using Restaurant.Application.Commands.CategoryCommands.DeleteCategory;
using Restaurant.Application.Commands.CategoryCommands.UpdateCategory;
using Restaurant.Application.Queries.CategoryQueries.GetByCategoryType;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
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

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            if(id == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
