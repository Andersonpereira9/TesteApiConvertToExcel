using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
              //.ForMember(d => d.MenorData, o => o.MapFrom(m => m.Pedidos.Select(s => s.DataEntrega).OrderBy
              //.ForMember(d => d.Quantidade, o => o.MapFrom(m => m.Quantidade))
              ;
        }
    }
}
