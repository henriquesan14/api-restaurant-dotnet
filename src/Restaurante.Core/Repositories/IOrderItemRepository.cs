using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem> {

        Task<IReadOnlyList<OrderItem>> GetAllOrderItems(int pageSize, int pageNumber, int? status, DateTime? date);
        Task<int> GetCountOrderItemsToday(DateTime today);
    }
}
