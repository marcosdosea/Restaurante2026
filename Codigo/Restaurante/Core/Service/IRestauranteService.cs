using Core.DTO;

namespace Core.Service
{
    public interface IRestauranteService
    {

        uint Create(Restaurante restaurante);

        void Edit(Restaurante restaurante);

        void Delete(uint id);
        Restaurante? Get(uint id);

        IEnumerable<RestauranteDTO> GetAll();


    }
}
