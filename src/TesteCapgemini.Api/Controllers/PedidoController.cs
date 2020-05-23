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
        private readonly IServicePedido _servicePedido;
        private readonly Presenter _presenter;

        public PedidoController(IServicePedido servicePedido,
                                 Presenter presenter)
        {
            _servicePedido = servicePedido;
            _presenter = presenter;
        }

        [HttpPost]
        [Route(nameof(ImportarLista))]
        [ProducesResponseType(typeof(IEnumerable<PedidoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ImportarLista(IFormFile file)
        {
            _presenter.Handler(await _servicePedido.ImportarLista(file));

            return _presenter.ContentResult;
        }
    }
}