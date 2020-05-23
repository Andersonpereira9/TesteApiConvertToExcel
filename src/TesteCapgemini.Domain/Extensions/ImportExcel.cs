using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Domain.Extensions
{
    public static class ImportExcel
    {
        public static List<PedidoModel> Import(this IFormFile file)
        {
            var lista = new List<PedidoModel>();

            using (var stream = new MemoryStream())
            {
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet fileExcel = package.Workbook.Worksheets[0];
                    var rowCount = fileExcel.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        lista.Add(new PedidoModel
                        {
                            DataEntrega = Convert.ToDateTime(fileExcel.Cells[row, 1].Value.ToString().Trim()),
                            NomeProduto = fileExcel.Cells[row, 2].Value.ToString().Trim(),
                            Quantidade = Convert.ToInt32(fileExcel.Cells[row, 3].Value.ToString().Trim()),
                            ValorUnitario = Convert.ToDecimal(fileExcel.Cells[row, 4].Value.ToString().Trim())

                        });
                    }
                }

            }

            return lista;
        }
    }
}
