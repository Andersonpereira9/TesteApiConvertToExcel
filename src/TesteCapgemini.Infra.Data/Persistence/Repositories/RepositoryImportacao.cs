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

            _context.Add(request);
            _context.SaveChanges();

            return request;
        }
    }
}
