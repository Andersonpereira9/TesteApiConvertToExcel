using System;
using System.Collections.Generic;
using TesteCapgemini.Domain.Arguments.Base;

namespace TesteCapgemini.Domain.Arguments
{
    public class PedidoResponse : ResponseMessage
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime DataEntrega { get; set; }

        public PedidoResponse() { }
        public PedidoResponse(string message, bool error) : base(message, error) { }
        public PedidoResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
