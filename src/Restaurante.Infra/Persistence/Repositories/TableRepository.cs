using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        public TableRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
