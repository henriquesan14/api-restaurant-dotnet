﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public async Task<IReadOnlyList<CommonOrder>> GetAllCommonOrdersAsync(int pageSize, int pageNumber, int? status)
        {
            return await _context.Set<CommonOrder>()
                .AsNoTracking()
                .Where(o => (int) o.Status == status || !status.HasValue)
                .Include(o => o.Table)
                .Include(o => o.Employee)
                .Include(o => o.Client)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                    .ToListAsync();
        }

        public async Task<IReadOnlyList<DeliveryOrder>> GetAllDeliveryOrdersAsync(int pageSize, int pageNumber, int? status)
        {
            return await _context.Set<DeliveryOrder>()
                .AsNoTracking()
                .Where(o => (int)o.Status == status || !status.HasValue)
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
    }
}
