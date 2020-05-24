using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Infra.IoC.AutoMapper.Importacao
{
    public class ImportacaoProfile : Profile
    {
        public ImportacaoProfile()
        {
            CreateMap<ImportacaoModel, ImportacaoListaResponse>()
              .ForMember(d => d.Id, o => o.MapFrom(m => m.Id))
              .ForMember(d => d.DataImportacao, o => o.MapFrom(m => m.DataImportacao))
              .ForMember(d => d.QuantidadeItens, o => o.MapFrom(m => m.Pedidos.Select(s => s.Quantidade).Sum()))
              .ForMember(d => d.ValorTotal, o => o.MapFrom(m => m.Pedidos.Select(s => s.ValorUnitario * s.Quantidade).Sum()))
              .ForMember(d => d.MenorData, o => o.MapFrom(m => m.Pedidos.Select(s => s.DataEntrega)
                                                                        .OrderBy(o => o)
                                                                        .FirstOrDefault()))
              ;

            CreateMap<List<PedidoModel>, ImportacaoModel>()
              .ForMember(d => d.DataImportacao, o => o.MapFrom(m => DateTime.Now))
              .ForMember(d => d.Pedidos, o => o.MapFrom(m => m))
              ;

            CreateMap<ImportacaoModel, ImportacaoPorIdResponse>()
              .ForPath(d => d.Pedidos, o => o.MapFrom(m => m.Pedidos))
              ;

        }
    }
}
