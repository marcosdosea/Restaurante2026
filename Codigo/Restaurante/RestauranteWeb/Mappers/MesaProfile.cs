using AutoMapper;
using RestauranteWeb.Models;
using Core;
using Models;



namespace RestauranteWeb.Mappers

{
    public class MesaProfile : Profile
    {
        public MesaProfile()
        {
            CreateMap<MesaViewModel, Mesa>().ReverseMap();

        }
    }
}
