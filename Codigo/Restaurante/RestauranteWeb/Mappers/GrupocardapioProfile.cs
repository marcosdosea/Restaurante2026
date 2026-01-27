using AutoMapper;
using Core.DTO;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class GrupocardapioProfile : Profile
    {
        public GrupocardapioProfile()
        {
            CreateMap<GrupocardapioDTO, GrupocardapioViewModel>().ReverseMap();
        }
    }
}