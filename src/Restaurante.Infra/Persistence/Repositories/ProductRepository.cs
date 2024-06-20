using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(RestaurantContext context) : base(context)
        {
        }

    }
}
