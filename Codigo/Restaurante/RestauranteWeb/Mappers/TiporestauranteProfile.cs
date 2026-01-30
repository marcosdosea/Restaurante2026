using AutoMapper;


namespace RestauranteWeb.Mappers
{
    public class TiporestauranteProfile : Profile
    {
        public TiporestauranteProfile()
        {
            CreateMap<Core.Tiporestaurante, Models.TiporestauranteViewModel>().ReverseMap();
        }
    }
}
