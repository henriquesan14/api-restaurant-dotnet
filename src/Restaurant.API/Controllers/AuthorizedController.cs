using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Restaurant.API.Controllers
{
    public class AuthorizedController : ControllerBase
    {
        protected string UserId => User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
    }
}
