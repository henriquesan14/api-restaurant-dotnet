using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.OrderCommands.UpdateOrderItemCommand;
using Restaurant.Application.Queries.OrderItemQueries.GetAllOrdemItem;
using Restaurant.Application.Queries.OrderItemQueries.GetCountOrderItemByStatus;
using Restaurant.Application.Queries.OrderItemQueries.GetCountOrderItemToday;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;
using System;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems([FromQuery] PageFilter pageFilter, [FromQuery] int? status, [FromQuery] DateTime? date)
        {
            var query = new GetAllOrdemItemQuery(pageFilter, status, date);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("countToday")]
        public async Task<IActionResult> GetCountOrderItemToday()
        {
            var result = await _mediator.Send(new GetCountOrderItemTodayQuery());
            return Ok(result);
        }

        [HttpGet("countByStatus")]
        public async Task<IActionResult> GetCountOrderItemByStatus([FromQuery] OrderItemStatus status)
        {
            var result = await _mediator.Send(new GetCountOrderItemByStatusQuery(status));
            return Ok(result);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatusItem([FromBody] UpdateOrderItemCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
