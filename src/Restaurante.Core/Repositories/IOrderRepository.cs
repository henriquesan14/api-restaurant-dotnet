using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public  interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IReadOnlyList<Order>> GetAllAsync(int pageSize, int pageNumber);
    }
}
