using Microsoft.EntityFrameworkCore.Storage;
using Restaurant.Core.Repositories;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly RestaurantContext _dbContext;


        public IAddressRepository Addresses { get;}
        public ICategoryRepository Categories { get; }
        public IOrderItemRepository OrderItems { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public ITableRepository Tables { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(RestaurantContext dbContext, IAddressRepository addresses, ICategoryRepository categories,
            IOrderItemRepository orderItems, IOrderRepository orders, IProductRepository products, ITableRepository tables, IUserRepository users)
        {
            _dbContext = dbContext;
            Addresses = addresses;
            Categories = categories;
            OrderItems = orderItems;
            Orders = orders;
            Products = products;
            Tables = tables;
            Users = users;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }

        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            IsDisposing(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void IsDisposing(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
