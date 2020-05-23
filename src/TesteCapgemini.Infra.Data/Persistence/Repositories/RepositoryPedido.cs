using System.Collections.Generic;
using TesteCapgemini.Domain.Entities;
using TesteCapgemini.Domain.Interfaces.Repositories;

namespace TesteCapgemini.Infra.Data.Persistence.Repositories
{
    public class RepositoryPedido : IRepositoryPedido
    {

        protected readonly TesteCapgeminiContext _context;
        public IEnumerable<PedidoModel> AdicionarPedidos(List<PedidoModel> request)
        {

            _context.AddRange(request);

            _context.SaveChanges();
            return request;
        }
    }
}
