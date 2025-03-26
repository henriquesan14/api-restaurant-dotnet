using Restaurant.Core.Entities;
using Restaurant.Core.Entities.Statistic;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories.Base;

namespace Restaurant.Core.Repositories
{
    public  interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IReadOnlyList<CommonOrder>> GetAllCommonOrdersAsync(int pageSize, int pageNumber, OrderStatusEnum? status, DateTime? date);
        Task<int> GetCountCommonOrdersAsync(OrderStatusEnum? status, DateTime? date);
        Task<IReadOnlyList<DeliveryOrder>> GetAllDeliveryOrdersAsync(int pageSize, int pageNumber, OrderStatusEnum? status, DateTime? date);
        Task<int> GetCountDeliveryOrdersAsync(OrderStatusEnum? status, DateTime? date);
        Task<IReadOnlyCollection<Order>> GetOrdersByClient(int pageSize, int pageNumber, int clientId);
        Task<Order> GetOrderById(int id);
        Task<CommonOrder> GetCommonOrderByIdAsync(int id);
        Task<DeliveryOrder> GetDeliveryOrderByIdAsync(int id);
        Task<int> GetCountOrderToday(DateTime today);
        Task<decimal> GetTotalOrders(DateTime startDate, DateTime endDate);
        Task<List<StatisticOrder>> GetTotalDailyByMonth(int month);
    }
}
