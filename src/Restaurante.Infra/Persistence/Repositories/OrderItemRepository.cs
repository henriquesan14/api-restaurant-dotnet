﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<OrderItem>> GetAllOrderItems(int pageSize, int pageNumber, int? status, DateTime? date)
        {
            return await DbContext.Set<OrderItem>()
                .AsNoTracking()
                .Where(o => ((int)o.Status == status || !status.HasValue) && (date.HasValue && o.CreatedAt.Date == date.Value.Date || !date.HasValue))
                .Include(o => o.Order)
                .Include(o => o.MenuItem)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }

        public async Task<int> GetCountOrderItemsToday(DateTime today)
        {
            var result = await DbContext.Database.GetDbConnection().QueryAsync("SELECT * FROM OrderItems o WHERE CONVERT(DATE, o.CreatedAt , 120) = CONVERT(DATE, @Date, 120);", new { Date = today.Date });
            return result.Count();
        }

        public async Task<int> GetCountOrderItemsByStatus(int? status)
        {
            var result = await DbContext.Database.GetDbConnection().QueryAsync("SELECT * FROM OrderItems o WHERE o.Status = @Status", new { Status = status });
            return result.Count();
        }
    }
}
