using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(RestaurantContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<MenuItem> GetMenuItemIncludeItemsByIdAsync(int id)
        {
            return await DbContext.Set<MenuItem>()
                .Include(o => o.NeededProducts)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
