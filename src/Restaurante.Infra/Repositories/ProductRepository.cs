using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync(int pageSize, int pageNumber, string productName)
        {
            return await _context.Set<Product>()
                .AsNoTracking()
                    .Include(p => p.Category)
                        .Where(p => p.Name.Contains(productName) || productName == null)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }
    }
}
