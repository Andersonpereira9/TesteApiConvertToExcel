using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Domain.Interfaces.Repositories
{
    public interface IRepositoryImportacao
    {
        ImportacaoModel AdicionarImportacao(ImportacaoModel request);
        Task<IEnumerable<ImportacaoModel>> ObterImportacoes();
        Task<ImportacaoModel> ObterImportacaoPorId(int id);
    }
}
