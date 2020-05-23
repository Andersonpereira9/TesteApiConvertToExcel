using System.Collections.Generic;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Domain.Interfaces.Repositories
{
    public interface IRepositoryPedido
    {
        IEnumerable<PedidoModel> AdicionarPedidos(List<PedidoModel> request);
    }
}
