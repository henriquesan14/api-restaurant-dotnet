using Dapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Entities.Statistic;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<CommonOrder>> GetAllCommonOrdersAsync(int pageSize, int pageNumber, OrderStatusEnum? status, DateTime? date)
        {
            return await DbContext.Set<CommonOrder>()
                .AsNoTracking()
                .Where(o => (o.Status == status || status == null) && (o.CreatedAt.Date == date || date == null))
                .Include(o => o.Client)
                .Include(o => o.Table)
                .Include(o => o.CreatedByUser)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();

        }

        public async Task<int> GetCountCommonOrdersAsync(OrderStatusEnum? status, DateTime? date)
        {
            return await DbContext.Set<CommonOrder>().CountAsync(o => (o.Status == status || status == null) && (o.CreatedAt.Date == date || date == null));
        }

        public async Task<IReadOnlyList<DeliveryOrder>> GetAllDeliveryOrdersAsync(int pageSize, int pageNumber, OrderStatusEnum? status, DateTime? date)
        {
            return await DbContext.Set<DeliveryOrder>()
                .AsNoTracking()
                .Where(o => (o.Status == status || status == null) && (o.CreatedAt.Date == date || date == null))
                .Include(o => o.Client)
                .Include(o => o.Address)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }

        public async Task<int> GetCountDeliveryOrdersAsync(OrderStatusEnum? status, DateTime? date)
        {
            return await DbContext.Set<DeliveryOrder>().CountAsync(o => (o.Status == status || status == null) && (o.CreatedAt.Date == date || date == null));
        }

        public async Task<IReadOnlyCollection<Order>> GetOrdersByClient(int pageSize, int pageNumber, int clientId)
        {
            return await DbContext.Set<Order>()
                .AsNoTracking()
                .Where(o => o.ClientId == clientId)
                .Include(o => o.Client)
                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await DbContext.Set<Order>()
                .AsNoTracking()
                .Include(o => o.Items).ThenInclude(i => i.MenuItem).ThenInclude(p => p.MenuCategory)
                                    .FirstOrDefaultAsync(o => o.Id == id);
        }


        public async Task<CommonOrder> GetCommonOrderByIdAsync(int id)
        {
            return await DbContext.Set<CommonOrder>()
                .AsNoTracking()
                .Include(o => o.Table)
                .Include(o => o.CreatedByUser)
                .Include(o => o.Client)
                .Include(o => o.Items)
                    .ThenInclude(i => i.MenuItem)
                        .ThenInclude(m => m.MenuCategory)
                .Include(o => o.Items)
                    .ThenInclude(i => i.MenuItem)
                        .ThenInclude(m => m.NeededProducts)
                            .ThenInclude(np => np.Product) // Inclui detalhes de cada produto necessário
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<DeliveryOrder> GetDeliveryOrderByIdAsync(int id)
        {
            return await DbContext.Set<DeliveryOrder>()
                .AsNoTracking()
                .Include(o => o.Address)
                .Include(o => o.Client)
                .Include(o => o.Items)
                    .ThenInclude(i => i.MenuItem)
                        .ThenInclude(p => p.MenuCategory)
                .Include(o => o.Items)
                    .ThenInclude(i => i.MenuItem)
                        .ThenInclude(m => m.NeededProducts)
                            .ThenInclude(np => np.Product)
                                    .FirstOrDefaultAsync(o => o.Id == id);

        }

        public async Task<int> GetCountOrderToday(DateTime today)
        {
            var result = await DbContext.Database.GetDbConnection().QueryAsync("SELECT * FROM Orders o WHERE CONVERT(DATE, o.CreatedAt , 120) = CONVERT(DATE, @Date, 120);", new {Date = today.Date});
            return result.Count();
        }

        public async Task<decimal> GetTotalOrders(DateTime startDate, DateTime endDate)
        {
            var query = @"SELECT SUM(oi.Quantity * p.Price)
                        FROM RestaurantDb.dbo.OrderItems oi
                        INNER JOIN Products p
                        ON oi.ProductId = p.Id
                        INNER JOIN Orders o
                        ON o.Id = oi.OrderId
                        WHERE CONVERT(date, oi.CreatedAt )  >= @StartDate AND CONVERT(date, oi.CreatedAt ) <= @EndDate";
            var result = await DbContext.Database.GetDbConnection().QueryAsync<decimal>(query, new { StartDate = startDate, EndDate = endDate });
            return result.FirstOrDefault();
        }

        public async Task<List<StatisticOrder>> GetTotalDailyByMonth(int month)
        {
            var query = @"SELECT 
                        EXTRACT(DAY FROM o.""CreatedAt"") AS Day,
                        EXTRACT(MONTH FROM o.""CreatedAt"") AS Month,
                        SUM(o.""ValueTotal"") AS Total
                    FROM 
                       ""Orders"" o
                    WHERE 
                        EXTRACT(MONTH FROM o.""CreatedAt"") = @Month
                    GROUP BY 
                        EXTRACT(DAY FROM o.""CreatedAt""), EXTRACT(MONTH FROM o.""CreatedAt"")
                    ORDER BY 
                        EXTRACT(DAY FROM o.""CreatedAt"") ASC;";
            var result = await DbContext.Database.GetDbConnection().QueryAsync<StatisticOrder>(query, new { Month = month });
            return result.ToList();
        }
    }
}
