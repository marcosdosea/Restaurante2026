using AutoMapper;
using Core;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class ItemcardapioProfile : Profile
    {
        public ItemcardapioProfile()
        {
            CreateMap<ItemcardapioViewModel , Itemcardapio>().ReverseMap();
        }
    }
}
