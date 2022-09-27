using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Queries.UserQueries;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery loginAuthQuery)
        {
            var result = await _mediator.Send(loginAuthQuery);
            if (result == null)
            {
                return Unauthorized(new {
                    Message = "Usuário/Senha inválido(s)"
                });
            }
            return Ok(result);
        }
    }
}
