using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTemplate.Domain.Entities;

namespace TesteTemplate.Infra.Data.Persistence.Map
{
    public class MapImportacao : IEntityTypeConfiguration<ImportacaoModel>
    {
        public void Configure(EntityTypeBuilder<ImportacaoModel> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.DataImportacao)
                .IsRequired();

            builder.HasMany(f => f.Pedidos)
                .WithOne(p => p.Importacao);

            builder.ToTable("Importacao");


        }
    }
}
