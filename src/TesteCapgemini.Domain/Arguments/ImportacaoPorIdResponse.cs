using System;
using System.Collections.Generic;
using System.Text;
using TesteCapgemini.Domain.Arguments.Base;

namespace TesteCapgemini.Domain.Arguments
{
    public class ImportacaoPorIdResponse : ResponseMessage
    {
        public IList<PedidoResponse> Pedidos { get; set; }

        public ImportacaoPorIdResponse() { }
        public ImportacaoPorIdResponse(string message, bool error) : base(message, error) { }
        public ImportacaoPorIdResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
