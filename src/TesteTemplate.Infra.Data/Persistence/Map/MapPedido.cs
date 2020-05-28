using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTemplate.Domain.Entities;

namespace TesteTemplate.Infra.Data.Persistence.Map
{
    public class MapPedido : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.DataEntrega)
                .IsRequired();

            builder.Property(f => f.NomeProduto)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(f => f.Quantidade)
                 .IsRequired();

            builder.Property(f => f.ValorUnitario)
                 .IsRequired()
                 .HasColumnType("decimal(18,2)"); ;

            builder.ToTable("Pedido");
        }
    }
}
