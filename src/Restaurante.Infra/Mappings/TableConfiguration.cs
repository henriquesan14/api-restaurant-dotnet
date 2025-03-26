using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Tables");
            // Configuração da chave primária
            builder.HasKey(t => t.Id);

            // Configuração da propriedade 'Name'
            builder.Property(t => t.Name)
                .IsRequired()          // Torna o nome obrigatório
                .HasMaxLength(100);    // Define um tamanho máximo para o nome

            builder.Property(t => t.Capacity)
                .IsRequired();

            // Configuração da propriedade 'Status' (enum)
            builder.Property(t => t.Status)
                .IsRequired();         // Torna o status obrigatório

            // Relacionamento entre Table e CommonOrder
            // Supondo que a classe 'CommonOrder' tenha uma chave estrangeira 'TableId'
            builder.HasMany(t => t.Orders)
                .WithOne(o => o.Table)               // Pode ser configurado com a navegação inversa se necessário
                .HasForeignKey(o => o.TableId) // Defina a chave estrangeira se ela existir na tabela CommonOrder
                .OnDelete(DeleteBehavior.Cascade); // Apagar as ordens associadas se a mesa for deletada
        }
    }
}
