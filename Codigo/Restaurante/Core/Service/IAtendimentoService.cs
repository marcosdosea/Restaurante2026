using Core.DTO;

namespace Core.Service
{
    public interface IAtendimentoService
    {

        uint Create(Atendimento atendimento);

        void Edit(Atendimento atendimento);

        void Delete(uint id);
        Atendimento? Get(uint id);

        Atendimento? FinalizarAtendimento(uint idMesa);

        IEnumerable<AtendimentoDTO>GetAll();

        IEnumerable<AtendimentoDTO> GetByRestaurante(uint IdRestaurante);

    }
}
