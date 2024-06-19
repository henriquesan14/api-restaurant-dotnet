using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Infra.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, Core.Repositories.ICategoryRepository
    {
        public CategoryRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync(int pageSize, int pageNumber,CategoryTypeEnum? category, string name)
        {
            var result = await _context.Set<Category>()
                .AsNoTracking()
                    .Where(c => (c.CategoryType == category || !category.HasValue) && (c.Name.Contains(name) || name == null))
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                            .ToListAsync();
            return result;
        }
    }
}
