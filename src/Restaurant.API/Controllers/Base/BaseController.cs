using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Common;

namespace Restaurant.API.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResult(Result result)
        {
            if (result.IsFailure)
            {
                // Retorna o código de status e a mensagem de erro no formato desejado
                var errorResponse = new
                {
                    statusCode = (int)result.StatusCode,
                    message = result.Error
                };
                return StatusCode((int)result.StatusCode, errorResponse);
            }

            // Retorna o código de status específico definido no Result (por padrão OK)
            return StatusCode((int)result.StatusCode);
        }

        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsFailure)
            {
                // Retorna o código de status e a mensagem de erro no formato desejado
                var errorResponse = new
                {
                    statusCode = (int)result.StatusCode,
                    message = result.Error
                };
                return StatusCode((int)result.StatusCode, errorResponse);
            }

            return StatusCode((int)result.StatusCode, result.Value);
        }

        protected IActionResult HandleCreatedAtActionResult<T>(Result<T> result, string actionName, object routeValues)
        {
            if (result.IsFailure)
            {
                var errorResponse = new
                {
                    statusCode = (int)result.StatusCode,
                    message = result.Error
                };
                return StatusCode((int)result.StatusCode, errorResponse);
            }

            return CreatedAtAction(actionName, routeValues, result.Value);
        }

    }
}
