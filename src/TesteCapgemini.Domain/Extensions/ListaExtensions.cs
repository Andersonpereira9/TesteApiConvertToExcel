using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Domain.Extensions
{
    public static class ListaExtensions
    {
        public static List<string> ValidaImportacao(this List<PedidoModel> lista)
        {

            var errors = new List<string>();
            int linhaExcel = 1;

            foreach (var item in lista)
            {
                linhaExcel++;

                if (item.DataEntrega == null || item.DataEntrega.Date <= DateTime.Now.Date)
                    errors.Add("Data de entrega inválida na linha " + linhaExcel);

                if (item.NomeProduto == null || item.NomeProduto.Length > 50)
                    errors.Add("Nome do produto inválido na linha " + linhaExcel);

                if (item.Quantidade <= 0)
                    errors.Add("Quantidade inválida na linha " + linhaExcel);

                if (item.ValorUnitario <= 0)
                    errors.Add("Valor unitário inválido na linha " + linhaExcel);
            }

            return errors;

        }
    }
}
