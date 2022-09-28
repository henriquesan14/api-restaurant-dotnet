using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.OrderCommands.CreateCommonOrder;
using Restaurant.Application.Queries.OrderQueries.GetAllOrders;
using Restaurant.Application.Queries.ProductQueries.GetAllProducts;
using Restaurant.Application.ViewModels.Page;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommonOrderCommand command)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            command.EmployeeId = int.Parse(userId);
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter)
        {
            var query = new GetAllOrdersQuery(pageFilter);
            var order = await _mediator.Send(query);
            return Ok(order);
        }
    }
}
