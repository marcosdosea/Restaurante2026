using Core.DTO;

namespace Core.Service
{
    public interface IFuncionarioService
    {
        uint Create(FuncionarioDTO funcionario);
        void Edit(FuncionarioDTO funcionario);
        void Delete(uint id);
        FuncionarioDTO? Get(uint id);
        IEnumerable<FuncionarioDTO> GetAll();
    }
}