using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Controllers.Base;
using Restaurant.Application.Commands.MenuCommands.CreateMenu;
using Restaurant.Application.Queries.MenuQueries.GetAllMenus;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuController : BaseController
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMenuCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMenusQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }
    }
}
