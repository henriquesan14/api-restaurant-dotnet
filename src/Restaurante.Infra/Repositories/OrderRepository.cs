using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Repositories.Base;

namespace Restaurant.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
