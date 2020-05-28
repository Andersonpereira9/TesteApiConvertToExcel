using System;
using System.Collections.Generic;
using System.Text;
using TesteTemplate.Domain.Arguments.Base;

namespace TesteTemplate.Domain.Arguments
{
    public class ImportacaoPorIdResponse : ResponseMessage
    {
        public IList<PedidoResponse> Pedidos { get; set; }

        public ImportacaoPorIdResponse() { }
        public ImportacaoPorIdResponse(string message, bool error) : base(message, error) { }
        public ImportacaoPorIdResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
