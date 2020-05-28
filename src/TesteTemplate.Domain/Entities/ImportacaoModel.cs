using System;
using System.Collections.Generic;

namespace TesteTemplate.Domain.Entities
{
    public class ImportacaoModel
    {
        public int Id { get; set;}
        public DateTime DataImportacao { get; set; }
        public virtual ICollection<PedidoModel> Pedidos { get;set; }

    }
}
