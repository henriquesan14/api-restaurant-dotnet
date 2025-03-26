using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            // Definir a tabela
            builder.ToTable("Menus");

            // Definir chave primária
            builder.HasKey(m => m.Id);

            // Definir as propriedades
            builder.Property(m => m.Name)
                .IsRequired()                          // Nome é obrigatório
                .HasMaxLength(100);                    // Definindo o comprimento máximo para o nome

            builder.Property(m => m.Description)
                .HasMaxLength(500);                    // Definindo o comprimento máximo para a descrição

            // Relacionamento com MenuItem
            builder.HasMany(m => m.Items)        // Menu pode ter muitos MenuItems
                .WithOne()                            // MenuItem está relacionado a um Menu
                .HasForeignKey(mi => mi.MenuId)       // MenuItem tem uma chave estrangeira para Menu
                .OnDelete(DeleteBehavior.Cascade);    // Excluir MenuItems quando o Menu for excluído
        }
    }
}
