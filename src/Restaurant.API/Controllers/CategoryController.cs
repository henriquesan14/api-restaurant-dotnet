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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter, [FromQuery] CategoryType? categoryType, [FromQuery] string name)
        {
            var query = new GetAllCategoriesQuery(pageFilter, categoryType, name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            if (id == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
