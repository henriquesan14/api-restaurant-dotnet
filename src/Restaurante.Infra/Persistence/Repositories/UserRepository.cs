using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await DbContext.Set<User>().Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
