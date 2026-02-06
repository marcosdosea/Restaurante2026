
namespace Core.Service
{
    public interface IItemcardapioService
    {
        uint Create(Itemcardapio itemcardapio);

        void Edit(Itemcardapio itemcardapio);
        void Delete(uint id);

        Itemcardapio? Get(uint id);

        IEnumerable<Itemcardapio> GetAll();
    }
}
