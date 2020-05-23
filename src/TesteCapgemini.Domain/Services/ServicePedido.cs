using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Extensions;
using TesteCapgemini.Domain.Interfaces.Repositories;
using TesteCapgemini.Domain.Interfaces.Services;

namespace TesteCapgemini.Domain.Services
{
    public class ServicePedido : IServicePedido
    {

        private readonly IRepositoryPedido _repositoryPedido;
        private readonly IMapper _mapper;

        public ServicePedido(IRepositoryPedido repositoryPedido,
                             IMapper mapper)
        {
            _repositoryPedido = repositoryPedido;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoResponse>> ImportarLista(IFormFile request)
        {
            var validaArquivo = request.VerificaArquivoExcel();

            if (validaArquivo != null)
                return await validaArquivo;

            var lista = await request.Import();

            return _mapper.Map<IEnumerable<PedidoResponse>>
                           (_repositoryPedido.AdicionarPedidos(lista));

        }
    }
}

