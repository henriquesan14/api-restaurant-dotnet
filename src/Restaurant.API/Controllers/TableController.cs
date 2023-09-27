using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.TableCommands.CreateTable;
using Restaurant.Application.Queries.TableQueries.GetAllTables;
using Restaurant.Core.Enums;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TableStatus? status)
        {
            var query = new GetAllTablesQuery(status);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTableCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
