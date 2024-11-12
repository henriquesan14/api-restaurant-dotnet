using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;

namespace Restaurant.Core.Repositories
{
    public interface IMenuItemRepository : IBaseRepository<MenuItem>
    {
        Task<MenuItem> GetMenuItemIncludeItemsByIdAsync(int id);
    }
}
