using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetAllAsync(int pageSize, int pageNumber, string productName);
    }
}
