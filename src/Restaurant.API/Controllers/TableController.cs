using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.TableCommands.CreateTable;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTableCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
