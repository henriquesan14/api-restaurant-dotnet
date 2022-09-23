using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using System.Reflection;

namespace Restaurant.Infra
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CommonOrder> CommonOrders { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
