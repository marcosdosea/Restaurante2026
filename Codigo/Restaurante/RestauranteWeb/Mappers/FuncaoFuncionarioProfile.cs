using AutoMapper;
using RestauranteWeb.Models;
using Core;
using Models;



namespace Mappers
{
    public class FuncaoFuncionarioProfile :Profile
    {
        public FuncaoFuncionarioProfile()
        {
            CreateMap<FuncaofuncionarioViewModel, Funcaofuncionario>().ReverseMap();
                
        }

    }
}
