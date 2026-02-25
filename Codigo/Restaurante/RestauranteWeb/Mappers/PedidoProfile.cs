using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using AutoMapper;
using RestauranteWeb.Models;
using Core;
namespace RestauranteWeb.Mappers
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            
        }
    }
}