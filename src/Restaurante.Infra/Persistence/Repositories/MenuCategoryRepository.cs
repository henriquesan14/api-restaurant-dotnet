using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class MenuCategoryRepository : BaseRepository<MenuCategory>, IMenuCategoryRepository
    {
        public MenuCategoryRepository(RestaurantContext dbContext) : base(dbContext)
        {
        }
    }
}
