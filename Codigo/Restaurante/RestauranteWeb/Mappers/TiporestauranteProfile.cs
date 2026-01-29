using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class TiporestauranteProfile : Profile
    {
        public TiporestauranteProfile()
        {
            CreateMap<TiporestauranteModel, Tiporestaurante>().ReverseMap();
        }
    }
}
