using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Core.Entities;
using Restaurant.Core.Entities.Statistic;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        IConfiguration _configuration;
        public OrderRepository(RestaurantContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }
        public async Task<IReadOnlyList<CommonOrder>> GetAllCommonOrdersAsync(int pageSize, int pageNumber, int? status, DateTime? date)
        {
            return await _context.Set<CommonOrder>()
                .AsNoTracking()
                .Where(o => ((int) o.Status == status || !status.HasValue) && (date.HasValue && o.CreatedAt.Value.Date == date.Value.Date || !date.HasValue))
                .Include(o => o.Table)
                .Include(o => o.Employee)
                .Include(o => o.Client)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }

        public async Task<IReadOnlyList<DeliveryOrder>> GetAllDeliveryOrdersAsync(int pageSize, int pageNumber, int? status, DateTime? date)
        {
            return await _context.Set<DeliveryOrder>()
                .AsNoTracking()
                .Where(o => ((int)o.Status == status || !status.HasValue) && (date.HasValue && o.CreatedAt.Value.Date == date.Value.Date || !date.HasValue))
                .Include(o => o.Client)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }

        public async Task<IReadOnlyCollection<Order>> GetOrdersByClient(int pageSize, int pageNumber, int clientId)
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Where(o => o.ClientId == clientId)
                .Include(o => o.Client)
                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }

        public async Task<CommonOrder> GetCommonOrderByIdAsync(int id)
        {
            return await _context.Set<CommonOrder>()
                .AsNoTracking()
                .Include(o => o.Table)
                .Include(o => o.Employee)
                .Include(o => o.Client)
                .Include(o => o.Items).ThenInclude(i => i.Product).ThenInclude(p => p.Category)
                                    .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<DeliveryOrder> GetDeliveryOrderByIdAsync(int id)
        {
            return await _context.Set<DeliveryOrder>()
                .AsNoTracking()
                .Include(o => o.Address)
                .Include(o => o.Client)
                .Include(o => o.Items).ThenInclude(i => i.Product).ThenInclude(p => p.Category)
                                    .FirstOrDefaultAsync(o => o.Id == id);

        }

        public async Task<int> GetCountOrderToday(DateTime today)
        {
            var result = await _context.Database.GetDbConnection().QueryAsync("SELECT * FROM Orders o WHERE CONVERT(DATE, o.CreatedAt , 120) = CONVERT(DATE, @Date, 120);", new {Date = today.Date});
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
            var result = await _context.Database.GetDbConnection().QueryAsync<decimal>(query, new { StartDate = startDate, EndDate = endDate });
            return result.FirstOrDefault();
        }

        public async Task<List<StatisticOrder>> GetTotalDailyByMonth(int month)
        {
            var query = @"SELECT DAY(o.CreatedAt ) AS Day,
                            MONTH(o.CreatedAt ) AS Month,
                            SUM(o.ValueTotal ) AS Total 
                            FROM Orders o 
                            WHERE MONTH(o.CreatedAt) = @Month
                            GROUP BY DAY(o.CreatedAt ),MONTH(o.CreatedAt) 
                            ORDER BY DAY(o.CreatedAt) ASC";
            var result = await _context.Database.GetDbConnection().QueryAsync<StatisticOrder>(query, new { Month = month });
            return result.ToList();
        }
    }
}
