using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IReadOnlyCollection<Address>> GetAddressByUser(long userId);
    }
}
