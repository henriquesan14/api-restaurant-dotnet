using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ProductCategory>> GetAllAsync(int pageSize, int pageNumber, string name)
        {
            var result = await DbContext.Set<ProductCategory>()
                .AsNoTracking()
                    .Where(c => ((c.Name.Contains(name) || name == null)))
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                            .ToListAsync();
            return result;
        }
    }
}
