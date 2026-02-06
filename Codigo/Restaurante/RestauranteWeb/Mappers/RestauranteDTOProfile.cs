using AutoMapper;
using Core;
using Core.DTO;
using RestauranteWeb.Models;

namespace Mappers
{
    public class RestauranteDTOProfile : Profile
    {
        public RestauranteDTOProfile()
        {

            CreateMap<RestauranteViewModel, RestauranteDTO>().ReverseMap();
        }
    }
}