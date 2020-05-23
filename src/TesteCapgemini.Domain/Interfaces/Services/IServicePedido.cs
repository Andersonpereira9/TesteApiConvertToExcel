using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Arguments;

namespace TesteCapgemini.Domain.Interfaces.Services
{
    public interface IServicePedido
    {
        Task<IEnumerable<PedidoResponse>> ImportarLista(IFormFile request);
    }
}
