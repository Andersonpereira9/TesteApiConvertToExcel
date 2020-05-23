using Microsoft.EntityFrameworkCore;
using System.Linq;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Infra.Data.Persistence
{
    public class TesteCapgeminiContext : DbContext
    {
        public TesteCapgeminiContext(DbContextOptions<TesteCapgeminiContext> options) : base(options)
        {

        }

        public DbSet<PedidoModel> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteCapgeminiContext).Assembly);

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
