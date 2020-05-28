using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTemplate.Domain.Entities;
using TesteTemplate.Domain.Interfaces.Repositories;

namespace TesteTemplate.Infra.Data.Persistence.Repositories
{
    public class RepositoryImportacao : IRepositoryImportacao
    {

        protected readonly TesteTemplateContext _context;

        public RepositoryImportacao(TesteTemplateContext context)
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
