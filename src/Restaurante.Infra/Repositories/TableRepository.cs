using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;

namespace Restaurant.Infra.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
