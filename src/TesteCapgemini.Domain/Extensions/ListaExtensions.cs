using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Domain.Extensions
{
    public static class ListaExtensions
    {
        public async static Task<IEnumerable<ImportacaoListaResponse>> ValidaImportacao(this List<PedidoModel> lista)
        {

            var response = new List<ImportacaoListaResponse>();
            int linhaExcel = 1;

            foreach (var item in lista)
            {
                linhaExcel++;

                if (item.DataEntrega == null || item.DataEntrega <= DateTime.Now)
                    response.Add(new ImportacaoListaResponse("Data de entrega inválida na linha " + linhaExcel , true));

                if (item.NomeProduto == null || item.NomeProduto.Length > 50)
                    response.Add(new ImportacaoListaResponse("Nome do produto inválido na linha " + linhaExcel, true));

                if (item.Quantidade <= 0)
                    response.Add(new ImportacaoListaResponse("Quantidade inválida na linha " + linhaExcel, true));

                if (item.ValorUnitario <= 0)
                    response.Add(new ImportacaoListaResponse("Valor unitário inválido na linha " + linhaExcel, true));
            }

            return response;

        }
    }
}
