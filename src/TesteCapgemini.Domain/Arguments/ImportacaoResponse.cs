using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TesteCapgemini.Domain.Arguments.Base;

namespace TesteCapgemini.Domain.Arguments
{
    public class ImportacaoResponse : ResponseMessage
    {

        public int Id { get; set; }
        public DateTime DataImportacao { get; set; }
        public int QuantidadeItens { get; set; }
        public DateTime MenorData { get; set; }
        public decimal ValorTotal { get; set; }

        public ImportacaoResponse() { }
        public ImportacaoResponse(string message, bool error) : base(message, error) { }
        public ImportacaoResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
