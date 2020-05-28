using System;
using System.Collections.Generic;
using TesteTemplate.Domain.Arguments.Base;

namespace TesteTemplate.Domain.Arguments
{
    public class ImportacaoListaResponse : ResponseMessage
    {

        public int Id { get; set; }
        public DateTime DataImportacao { get; set; }
        public int QuantidadeItens { get; set; }
        public DateTime MenorData { get; set; }
        public decimal ValorTotal { get; set; }

        public ImportacaoListaResponse() { }
        public ImportacaoListaResponse(string message, bool error) : base(message, error) { }
        public ImportacaoListaResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
