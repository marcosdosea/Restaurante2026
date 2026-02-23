using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using AutoMapper;
using RestauranteWeb.Models;
namespace RestauranteWeb.Mappers
{
    public class PedidoDTOProfile : Profile
    {
        public PedidoDTOProfile()
        {
            CreateMap<PedidoDTO, PedidoViewModel>().ReverseMap();
            
        }
    }
}