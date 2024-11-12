using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class MenuItemProductConfiguration: IEntityTypeConfiguration<MenuItemProduct>
    {
        public void Configure(EntityTypeBuilder<MenuItemProduct> builder)
        {
            builder.ToTable("MenuItemProducts");


            builder.HasKey(mp => mp.Id);

            builder.HasOne(mp => mp.MenuItem)
                .WithMany(i => i.NeededProducts)
                .HasForeignKey(mp => mp.MenuItemId);

            builder.HasOne(mp => mp.Product)
                .WithMany(p => p.MenuItemProducts)
                .HasForeignKey(mp => mp.ProductId);

            builder.Property(mp => mp.QuantityRequired)
                .HasColumnType("decimal(18,2)");
        }
    }
}
