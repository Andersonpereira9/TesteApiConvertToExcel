using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Entities;
using TesteCapgemini.Domain.Extensions;
using TesteCapgemini.Domain.Interfaces.Repositories;
using TesteCapgemini.Domain.Interfaces.Services;

namespace TesteCapgemini.Domain.Services
{
    public class ServiceImportacao : IServiceImportacao
    {

        private readonly IRepositoryImportacao _repositoryImportacao;
        private readonly IMapper _mapper;

        public ServiceImportacao(IRepositoryImportacao repositoryImportacao,
                             IMapper mapper)
        {
            _repositoryImportacao = repositoryImportacao;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImportacaoListaResponse>> ImportarLista(IFormFile request)
        {
            var validaArquivo = request.VerificaArquivoExcel();

            if (validaArquivo.Result.Count() > 0)
                return await validaArquivo;
            
            var lista = await request.Import();

            var validaImportacao = await lista.ValidaImportacao();

            if (validaImportacao.Count() > 0)
                return validaImportacao;

            var importacao = new ImportacaoModel
            {
                Pedidos = lista,
                DataImportacao = DateTime.Now
            };

            return _mapper.Map<IEnumerable<ImportacaoListaResponse>>
                          (_repositoryImportacao.AdicionarImportacao(importacao));

        }
    }
}

