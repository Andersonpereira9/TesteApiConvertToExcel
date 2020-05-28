using System;
using System.Collections.Generic;
using TesteTemplate.Domain.Arguments.Base;

namespace TesteTemplate.Domain.Arguments
{
    public class PedidoResponse : ResponseMessage
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal ValorTotal { get; set; }

        public PedidoResponse() { }
        public PedidoResponse(string message, bool error) : base(message, error) { }
        public PedidoResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
