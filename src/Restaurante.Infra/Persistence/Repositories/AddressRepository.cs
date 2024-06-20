using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Address>> GetAddressByUser(long userId)
        {
            var result = await DbContext.Set<Address>()
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .ToListAsync();
            return result;
        }
    }
}
