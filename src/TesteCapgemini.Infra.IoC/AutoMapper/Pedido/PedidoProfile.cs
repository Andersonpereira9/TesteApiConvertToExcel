﻿using AutoMapper;
using TesteCapgemini.Domain.Arguments;
using TesteCapgemini.Domain.Entities;

namespace TesteCapgemini.Infra.IoC.AutoMapper.Pedido
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<PedidoModel, PedidoResponse>()
              .ForMember(d => d.Id, o => o.MapFrom(m => m.Id))
              .ForMember(d => d.NomeProduto, o => o.MapFrom(m => m.NomeProduto))
              .ForMember(d => d.DataEntrega, o => o.MapFrom(m => m.DataEntrega))
              .ForMember(d => d.Quantidade, o => o.MapFrom(m => m.Quantidade))
              .ForMember(d => d.ValorTotal, o => o.MapFrom(m => m.Quantidade * m.ValorUnitario))
              ;

        }
        
    }
}
