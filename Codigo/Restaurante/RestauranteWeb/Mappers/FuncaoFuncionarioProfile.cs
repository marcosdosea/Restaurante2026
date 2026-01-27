using AutoMapper;
using Models;
using Core;


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
