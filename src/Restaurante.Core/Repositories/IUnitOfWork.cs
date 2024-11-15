namespace Restaurant.Core.Repositories
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        IProductCategoryRepository Categories { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ITableRepository Tables { get; }
        IUserRepository Users { get; }
        IMenuItemRepository MenuItems { get; }
        IMenuCategoryRepository MenuCategories { get; }
        IMenuRepository Menus { get; }
        IStockProductRepository StockProducts { get; }
        IStockMovementRepository StockMovements { get; }
        INotificationRepository Notifications { get; }

        Task<int> CompleteAsync();
        Task BeginTransaction();
        Task CommitAsync();
    }
}
