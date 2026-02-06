using AutoMapper;
using Core;
using Core.DTO;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<FuncionarioDTO, FuncionarioViewModel>().ReverseMap();
            CreateMap<FuncionarioDTO, Funcionario>().ReverseMap();
        }
    }
}