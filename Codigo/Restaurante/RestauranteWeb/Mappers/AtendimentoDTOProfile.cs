using AutoMapper;
using Core;
using Core.DTO;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class AtendimentoDTOProfile : Profile
    {
        public AtendimentoDTOProfile() 
        {
            CreateMap<AtendimentoViewModel, AtendimentoDTO>().ReverseMap();
        }
    }
}
