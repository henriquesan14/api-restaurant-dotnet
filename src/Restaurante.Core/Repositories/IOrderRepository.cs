using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public  interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IReadOnlyList<CommonOrder>> GetAllCommonOrdersAsync(int pageSize, int pageNumber);
        Task<IReadOnlyList<DeliveryOrder>> GetAllDeliveryOrdersAsync(int pageSize, int pageNumber);
        Task<CommonOrder> GetCommonOrderByIdAsync(int id);
        Task<DeliveryOrder> GetDeliveryOrderByIdAsync(int id);
    }
}
