using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TesteCapgemini.Api.Controllers.Base;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Interfaces.Services;

namespace TesteCapgemini.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IServiceImportacao _serviceImportacao;
        private readonly Presenter _presenter;

        public PedidoController(IServiceImportacao serviceImportacao,
                                 Presenter presenter)
        {
            _serviceImportacao = serviceImportacao;
            _presenter = presenter;
        }

        [HttpPost]
        [Route(nameof(ImportarLista))]
        [ProducesResponseType(typeof(IEnumerable<ImportacaoListaResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportarLista(IFormFile file)
        {
            _presenter.Handler(await _serviceImportacao.ImportarLista(file));

            return _presenter.ContentResult;
        }
    }
}