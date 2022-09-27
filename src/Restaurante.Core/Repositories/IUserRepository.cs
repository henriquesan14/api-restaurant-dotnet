using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
