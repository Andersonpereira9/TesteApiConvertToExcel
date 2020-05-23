using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Domain.Extensions
{
    public static class ImportExcel
    {
        public async static Task<List<PedidoModel>> Import(this IFormFile file)
        {
            var lista = new List<PedidoModel>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using var package = new ExcelPackage(stream);
                ExcelWorksheet fileExcel = package.Workbook.Worksheets[0];

                var rowCount = fileExcel.Dimension.End.Row;

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

            return lista;
        }
    }
}
