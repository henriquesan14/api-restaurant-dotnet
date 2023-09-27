using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(RestaurantContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Table>> GetAllTables(TableStatus? status)
        {
            var result = await _context.Set<Table>()
                .AsNoTracking()
                .Where(t => t.Status == status || !status.HasValue)
                .ToListAsync();
            return result;
        }

        public async Task UpdateStatusAsync(int id, TableStatus status)
        {
            var table = await _context.Tables.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            table.Status = status;
            table.UpdatedAt = DateTime.Now;
            _context.Entry(table).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
