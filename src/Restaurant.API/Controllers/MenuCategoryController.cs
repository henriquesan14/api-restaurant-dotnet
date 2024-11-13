using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Controllers.Base;
using Restaurant.Application.Commands.MenuCategoryCommands.CreateMenuCategory;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuCategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public MenuCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    } 
}
