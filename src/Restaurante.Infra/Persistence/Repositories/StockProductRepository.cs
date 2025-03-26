﻿using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class StockProductRepository : BaseRepository<StockProduct>, IStockProductRepository
    {
        public StockProductRepository(RestaurantContext dbContext) : base(dbContext)
        {
        }
    }
}
