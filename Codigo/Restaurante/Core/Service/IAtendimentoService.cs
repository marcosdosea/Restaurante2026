using Core.DTO;

namespace Core.Service
{
    public interface IAtendimentoService
    {

        uint Create(Atendimento atendimento);

        void Edit(Atendimento atendimento);

        void Delete(uint id);
        Atendimento? Get(uint id);

        IEnumerable<AtendimentoDTO>GetAll();


    }
}
