using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.OrderCommands.CreateCommonOrder;
using Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder;
using Restaurant.Application.Commands.OrderCommands.UpdateOrderItemCommand;
using Restaurant.Application.Queries.OrderQueries.GetAllOrders;
using Restaurant.Application.Queries.OrderQueries.GetCountOrderToday;
using Restaurant.Application.Queries.OrderQueries.GetOrder;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("common")]
        public async Task<IActionResult> CreateCommonOrder([FromBody] CreateCommonOrderCommand command)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            command.EmployeeId = int.Parse(userId);
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("delivery")]
        public async Task<IActionResult> CreateDeliveryOrder([FromBody] CreateDeliveryOrderCommand command)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter, [FromQuery] int? status, [FromQuery] DateTime? date, [FromQuery] OrderType orderType = OrderType.COMMON)
        {
            var query = new GetAllOrdersQuery(pageFilter, orderType, status, date);
            var order = await _mediator.Send(query);
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] OrderType orderType = OrderType.COMMON)
        {
            var query = new GetOrderQuery(id, orderType);
            var order = await _mediator.Send(query);
            return Ok(order);
        }

        [HttpPut("itens")]
        public async Task<IActionResult> UpdateStatusItem([FromBody] UpdateOrderItemCommand command)
        {
            var result = await _mediator.Send(command);
            if(result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpGet("countToday")]
        public async Task<IActionResult> GetCountOrderToday()
        {
            var result = await _mediator.Send(new GetCountOrderTodayQuery());
            return Ok(result);
        }
    }
}
