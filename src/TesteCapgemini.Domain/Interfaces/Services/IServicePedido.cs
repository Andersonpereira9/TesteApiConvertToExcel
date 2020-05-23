using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TesteCapgemini.Domain.Arguments;

namespace TesteCapgemini.Domain.Interfaces.Services
{
    public interface IServicePedido
    {
        IEnumerable<PedidoResponse> ImportarLista(IFormFile request );
    }
}
