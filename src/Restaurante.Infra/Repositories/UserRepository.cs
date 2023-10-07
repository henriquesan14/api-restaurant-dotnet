using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
