using Restaurant.Core.Entities;

namespace Restaurant.Core.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
