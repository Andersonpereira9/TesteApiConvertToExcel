using System;

namespace TesteTemplate.Domain.Entities
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime DataEntrega { get; set; }
        public int ImportacaoId { get; set; }
        public virtual ImportacaoModel Importacao { get; set; }

    }
}
