using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TesteTemplate.Api.Controllers.Base;
using TesteTemplate.Domain.Arguments;
using TesteTemplate.Domain.Interfaces.Services;

namespace TesteTemplate.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImportacaoController : ControllerBase
    {
        private readonly IServiceImportacao _serviceImportacao;
        private readonly Presenter _presenter;

        public ImportacaoController(IServiceImportacao serviceImportacao,
                                 Presenter presenter)
        {
            _serviceImportacao = serviceImportacao;
            _presenter = presenter;
        }

        [HttpPost]
        [Route(nameof(ImportarLista))]
        [ProducesResponseType(typeof(ImportacaoListaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportarLista(IFormFile file)
        {
            _presenter.Handler(await _serviceImportacao.ImportarLista(file));

            return _presenter.ContentResult;
        }

        [HttpGet]
        [Route(nameof(ObterImportacoes))]
        [ProducesResponseType(typeof(IEnumerable<ImportacaoListaResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterImportacoes()
        {
            _presenter.Handler(await _serviceImportacao.ObterImportacoes());

            return _presenter.ContentResult;
        }

        [HttpGet]
        [Route(nameof(ObterImportacaoPorId))]
        [ProducesResponseType(typeof(ImportacaoPorIdResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterImportacaoPorId(int id)
        {
            _presenter.Handler(await _serviceImportacao.ObterImportacaoPorId(id));

            return _presenter.ContentResult;
        }
    }
}