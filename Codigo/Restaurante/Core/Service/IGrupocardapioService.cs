using Core.DTO;

namespace Core.Service
{
    public interface IGrupocardapioService
    {
        uint Create(GrupocardapioDTO grupo);
        void Edit(GrupocardapioDTO grupo);
        void Delete(uint id);
        GrupocardapioDTO Get(uint id);
        IEnumerable<GrupocardapioDTO> GetAll();
    }
}