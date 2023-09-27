using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public  interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IReadOnlyList<CommonOrder>> GetAllCommonOrdersAsync(int pageSize, int pageNumber, int? status, DateTime? date);
        Task<IReadOnlyList<DeliveryOrder>> GetAllDeliveryOrdersAsync(int pageSize, int pageNumber, int? status, DateTime? date);
        Task<IReadOnlyCollection<Order>> GetOrdersByClient(int pageSize, int pageNumber, int clientId);
        Task<CommonOrder> GetCommonOrderByIdAsync(int id);
        Task<DeliveryOrder> GetDeliveryOrderByIdAsync(int id);
        Task<int> GetCountOrderToday(DateTime today);
        Task<decimal> GetTotalOrders(DateTime startDate, DateTime endDate);
    }
}
