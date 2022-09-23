using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;

namespace Restaurant.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
