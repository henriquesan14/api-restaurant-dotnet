using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.TableCommands.CreateTable;
using Restaurant.Application.Commands.TableCommands.DeleteTable;
using Restaurant.Application.Commands.TableCommands.UpdateTable;
using Restaurant.Application.Queries.TableQueries.GetAllTables;
using Restaurant.Core.Enums;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TableStatus? status)
        {
            var query = new GetAllTablesQuery(status);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTableCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTableCommand command)
        {
            var id = await _mediator.Send(command);
            if (id == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTableCommand(id);
            var result = await _mediator.Send(command);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
