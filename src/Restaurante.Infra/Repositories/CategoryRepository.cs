using Restaurant.Core.Entities;
using Restaurant.Infra.Repositories.Base;

namespace Restaurant.Infra.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, Core.Repositories.ICategoryRepository
    {
        public CategoryRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
