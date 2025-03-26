using Microsoft.EntityFrameworkCore.Storage;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Repositories;
using Restaurant.Infra.Events;

namespace Restaurant.Infra.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly RestaurantContext _dbContext;
        private readonly DomainEventDispatcher _domainEventDispatcher;


        public IAddressRepository Addresses { get;}
        public IProductCategoryRepository Categories { get; }
        public IOrderItemRepository OrderItems { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public ITableRepository Tables { get; }
        public IUserRepository Users { get; }
        public IMenuItemRepository MenuItems { get; }
        public IMenuCategoryRepository MenuCategories { get; }
        public IMenuRepository Menus { get; }
        public IStockProductRepository StockProducts { get; }
        public IStockMovementRepository StockMovements { get; }
        public INotificationRepository Notifications { get; }

        public UnitOfWork(RestaurantContext dbContext, DomainEventDispatcher domainEventDispatcher, IAddressRepository addresses, IProductCategoryRepository categories,
            IOrderItemRepository orderItems, IOrderRepository orders, IProductRepository products, ITableRepository tables, IUserRepository users, IMenuItemRepository menuItems, IStockProductRepository stockProducts, IStockMovementRepository stockMovements, IMenuCategoryRepository menuCategories, IMenuRepository menus, INotificationRepository notifications)
        {
            _dbContext = dbContext;
            _domainEventDispatcher = domainEventDispatcher;
            Addresses = addresses;
            Categories = categories;
            OrderItems = orderItems;
            Orders = orders;
            Products = products;
            Tables = tables;
            Users = users;
            MenuItems = menuItems;
            StockProducts = stockProducts;
            StockMovements = stockMovements;
            MenuCategories = menuCategories;
            Menus = menus;
            Notifications = notifications;
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
            // Captura todos os eventos de domínio de entidades rastreadas
            var domainEvents = _dbContext.ChangeTracker
                .Entries<Entity>()
                .SelectMany(e => e.Entity.DomainEvents)
                .ToList();

            // Limpa os eventos para evitar reprocessamento
            foreach (var entity in _dbContext.ChangeTracker.Entries<Entity>())
            {
                entity.Entity.ClearDomainEvents();
            }

            // Salva as mudanças no banco de dados
            var result = await _dbContext.SaveChangesAsync();

            // Dispara todos os eventos de domínio coletados
            if (domainEvents.Any())
            {
                await _domainEventDispatcher.DispatchAsync(domainEvents);
            }

            return result;
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
