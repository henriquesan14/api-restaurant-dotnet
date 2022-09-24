using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.CreateProduct;
using Restaurant.Application.Queries.GetAllProducts;
using Restaurant.Application.ViewModels.Page;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageFilter pageFilter)
        {
            var query = new GetAllProductsQuery(pageFilter);
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
