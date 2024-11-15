using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(RestaurantContext dbContext) : base(dbContext)
        {
        }
    }
}
