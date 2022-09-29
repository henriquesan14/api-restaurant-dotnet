using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.OrderCommands.CreateCommonOrder;
using Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder;
using Restaurant.Application.Queries.OrderQueries.GetAllOrders;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;
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
            return Ok(id);
        }

        [HttpPost("delivery")]
        public async Task<IActionResult> CreateDeliveryOrder([FromBody] CreateDeliveryOrderCommand command)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter, [FromQuery] OrderType orderType = OrderType.COMMON)
        {
            var query = new GetAllOrdersQuery(pageFilter, orderType);
            var order = await _mediator.Send(query);
            return Ok(order);
        }
    }
}
