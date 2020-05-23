using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Extensions;
using TesteCapgemini.Domain.Interfaces.Repositories;
using TesteCapgemini.Domain.Interfaces.Services;

namespace TesteCapgemini.Domain.Services
{
    public class ServiceImportacao : IServiceImportacao
    {

        private readonly IRepositoryImportacao _repositoryPedido;
        private readonly IMapper _mapper;

        public ServiceImportacao(IRepositoryImportacao repositoryPedido,
                             IMapper mapper)
        {
            _repositoryPedido = repositoryPedido;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoResponse>> ImportarLista(IFormFile request)
        {
            var validaArquivo = request.VerificaArquivoExcel();

            if (validaArquivo.Result.Count() > 0)
                return await validaArquivo;
            
            var lista = await request.Import();

            var validaPedidos = await lista.ValidaPedidos();

            if (validaPedidos.Count() > 0)
                return validaPedidos;

            return _mapper.Map<IEnumerable<PedidoResponse>>
                           (_repositoryPedido.AdicionarPedidos(lista));

        }
    }
}

