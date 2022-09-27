using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.UserCommands.CreateUserCommand;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
