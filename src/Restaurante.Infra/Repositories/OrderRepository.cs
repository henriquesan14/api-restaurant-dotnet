using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context) : base(context)
        {
            
        }
        public async Task<IReadOnlyList<Order>> GetAllAsync(int pageSize, int pageNumber)
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Items).ThenInclude(i => i.Product).ThenInclude(p => p.Category)
                .Include(o => o.Payments)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }
    }
}
