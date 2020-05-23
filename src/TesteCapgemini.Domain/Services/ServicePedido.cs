using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (request == null || request.Length <= 0)
                return null;

            if (!Path.GetExtension(request.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                return null;
                
            var lista = await request.Import();

            return _mapper.Map<IEnumerable<PedidoResponse>>
                     (_repositoryPedido.AdicionarPedidos(lista));
            
        }
    }
}

