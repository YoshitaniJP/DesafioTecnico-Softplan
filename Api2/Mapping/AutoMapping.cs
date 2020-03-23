using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api2.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CalculaJurosRequest, CalculaJuros>()
                .ForMember(e => e.ValorEntrada, opts => opts.MapFrom(src => src.ValorInicial));
        }
    }
}
