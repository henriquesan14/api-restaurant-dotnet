using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            // Definir a tabela
            builder.ToTable("MenuItems");

            // Definir chave primária
            builder.HasKey(mi => mi.Id);

            // Definir as propriedades
            builder.Property(mi => mi.Name)
                .IsRequired()                          // Nome é obrigatório
                .HasMaxLength(100);                    // Definindo o comprimento máximo para o nome

            builder.Property(mi => mi.Description)
                .HasMaxLength(500);                    // Definindo o comprimento máximo para a descrição

            builder.Property(mi => mi.Price)
                .IsRequired()                          // Preço é obrigatório
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(500);

            builder.HasOne(mi => mi.MenuCategory)
                .WithMany(mc => mc.Items)
                .HasForeignKey(mi => mi.MenuCategoryId);

            // Definir o relacionamento com MenuItemProduct (produto necessário para o menu item)
            builder.HasMany(mi => mi.NeededProducts)
                .WithOne()                             // Assumindo que MenuItemProduct tem o MenuItem como chave estrangeira
                .HasForeignKey(mp => mp.MenuItemId);   // Relacionamento com MenuItemProduct

            // Definir o relacionamento com OrderItem
            builder.HasMany(mi => mi.OrderItems)     // MenuItem pode ter muitos OrderItems
                .WithOne(oi => oi.MenuItem)          // Cada OrderItem está relacionado a um MenuItem
                .HasForeignKey(oi => oi.MenuItemId); // Chave estrangeira em OrderItem

            builder.HasOne(mi => mi.Menu)
            .WithMany(m => m.Items)   // Um Menu pode ter muitos MenuItems
            .HasForeignKey(mi => mi.MenuId)  // Define explicitamente a chave estrangeira
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
