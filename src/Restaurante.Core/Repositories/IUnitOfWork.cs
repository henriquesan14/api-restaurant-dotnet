namespace Restaurant.Core.Repositories
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        ICategoryRepository Categories { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ITableRepository Tables { get; }
        IUserRepository Users { get; }
        
        Task<int> CompleteAsync();
        Task BeginTransaction();
        Task CommitAsync();
    }
}
