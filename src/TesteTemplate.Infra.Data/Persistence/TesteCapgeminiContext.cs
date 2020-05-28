using Microsoft.EntityFrameworkCore;
using System.Linq;
using TesteTemplate.Domain.Entities;

namespace TesteTemplate.Infra.Data.Persistence
{
    public class TesteTemplateContext : DbContext
    {
        public TesteTemplateContext(DbContextOptions<TesteTemplateContext> options) : base(options)
        {

        }

        public DbSet<ImportacaoModel> Importacao { get; set; }
        public DbSet<PedidoModel> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteTemplateContext).Assembly);

            foreach (var relationship in modelBuilder.Model
                                                     .GetEntityTypes()
                                                     .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }


            base.OnModelCreating(modelBuilder);
        }
    }
}
