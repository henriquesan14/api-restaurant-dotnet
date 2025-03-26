using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Controllers.Base;
using Restaurant.Application.Commands.TableCommands.CreateTable;
using Restaurant.Application.Commands.TableCommands.DeleteTable;
using Restaurant.Application.Commands.TableCommands.UpdateStatusTable;
using Restaurant.Application.Commands.TableCommands.UpdateTable;
using Restaurant.Application.Queries.TableQueries.GetAllTables;
using Restaurant.Application.Queries.TableQueries.GetTable;
using Restaurant.Core.Enums;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TableController : BaseController
    {
        private readonly IMediator _mediator;

        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TableStatusEnum? status)
        {
            var query = new GetAllTablesQuery(status);
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTableQuery(id);
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTableCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusTableCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }
    }
}
