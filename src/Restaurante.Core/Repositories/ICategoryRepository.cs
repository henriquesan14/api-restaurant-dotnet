using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;

namespace Restaurant.Core.Repositories
{
    public interface ICategoryRepository : IBaseRepository<ProductCategory>
    {
        Task<IReadOnlyList<ProductCategory>> GetAllAsync(int pageSize, int pageNumber, string name);
    }
}
