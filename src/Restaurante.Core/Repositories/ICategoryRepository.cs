using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllAsync(int pageSize, int pageNumber, CategoryTypeEnum? category, string name);
    }
}
