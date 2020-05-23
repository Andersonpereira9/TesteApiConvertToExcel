using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IEnumerable<PedidoResponse> ImportarLista(IFormFile request)
        {

            if (request == null || request.Length <= 0)
                return null;

            if (!Path.GetExtension(request.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                return null;

            var lista = request.Import();

            var result = _mapper.Map<IEnumerable<PedidoResponse>>
                     (_repositoryPedido.AdicionarPedidos(lista));

            return result;
        }
    }
}

