using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface ITableRepository : IBaseRepository<Table>
    {
        Task<IReadOnlyCollection<Table>> GetAllTables(TableStatusEnum? status);
        Task UpdateStatusAsync(int id, TableStatusEnum status);
    }
}
