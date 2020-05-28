using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTemplate.Domain.Arguments;

namespace TesteTemplate.Domain.Interfaces.Services
{
    public interface IServiceImportacao
    {
        Task<ImportacaoListaResponse> ImportarLista(IFormFile request);
        Task<IEnumerable<ImportacaoListaResponse>> ObterImportacoes();
        Task<ImportacaoPorIdResponse> ObterImportacaoPorId(int id);
     }
}
