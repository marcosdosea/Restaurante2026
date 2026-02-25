using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace Mappers
{
    public class RestauranteProfile : Profile
    {
        public RestauranteProfile() 
        {
            
            CreateMap<RestauranteViewModel, Restaurante>().ReverseMap();
        }
    }
}
