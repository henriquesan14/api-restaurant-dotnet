using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Controllers.Base;
using Restaurant.Application.Commands.MenuItemCommands.CreateMenuItem;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuItemController : BaseController
    {
        private readonly IMediator _mediator;

        public MenuItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuItemCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}
