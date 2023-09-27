using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Address>> GetAddressByUser(long userId)
        {
            var result = await _context.Set<Address>()
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .ToListAsync();
            return result;
        }
    }
}
