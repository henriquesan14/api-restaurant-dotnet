using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurant.Application.Identity
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int Id => int.Parse(GetClaimsIdentity().First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public string Email => _accessor.HttpContext.User.Identity.Name!;
        public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value!;
        public string Role => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Role)?.Value!;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext!.User.Claims;
        }
    }
}
