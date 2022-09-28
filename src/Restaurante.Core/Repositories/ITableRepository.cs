using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface ITableRepository : IBaseRepository<Table>
    {
        Task UpdateStatusAsync(int id, TableStatus status);
    }
}
