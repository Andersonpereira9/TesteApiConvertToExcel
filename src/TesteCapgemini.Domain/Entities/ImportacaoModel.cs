using System;
using System.Collections.Generic;

namespace TesteCapgemini.Domain.Entities
{
    public class ImportacaoModel
    {
        public int Id { get; set;}
        public DateTime DataImportacao { get; set; }
        public virtual ICollection<PedidoModel> Pedidos { get;set; }

    }
}
