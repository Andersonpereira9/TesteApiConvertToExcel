using System;

namespace TesteCapgemini.Domain.Entities
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
