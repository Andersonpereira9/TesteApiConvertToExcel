using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Entities;
using TesteCapgemini.Domain.Interfaces.Repositories;

namespace TesteCapgemini.Infra.Data.Persistence.Repositories
{
    public class RepositoryImportacao : IRepositoryImportacao
    {

        protected readonly TesteCapgeminiContext _context;

        public RepositoryImportacao(TesteCapgeminiContext context)
        {
            _context = context;
        }
        public ImportacaoModel AdicionarImportacao(ImportacaoModel request)
        {

            _context.Importacao.Add(request);
            _context.SaveChanges();

            return request;
        }

        public async Task<ImportacaoModel> ObterImportacaoPorId(int id)
        {

            return await _context.Importacao
                           .Where(w => w.Id == id)
                           .Include(p => p.Pedidos)
                           .FirstOrDefaultAsync();             
        }

        public async Task<IEnumerable<ImportacaoModel>> ObterImportacoes()
        {

            return await _context.Importacao
                         .Include(p => p.Pedidos)
                         .ToListAsync();
        }
    }
}
