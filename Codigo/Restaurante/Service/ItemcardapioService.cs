using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ItemcardapioService : IItemcardapioService
    {
        private readonly RestauranteContext context;

        public ItemcardapioService(RestauranteContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria uma nova Itemcardapio no banco de dados.
        /// </summary>
        /// <param name="itemcardapio">Itemcardapio a ser criado</param>
        /// <returns> o ID do novo Itemcardapio criado </returns>
        public uint Create(Itemcardapio itemcardapio)
        {
            context.Itemcardapios.Add(itemcardapio);
            context.SaveChanges();
            return itemcardapio.Id;
        }

        /// <summary>
        /// Deleta uma Itemcardapio do banco de dados pelo seu ID.
        /// </summary>
        /// <param name="id">ID da Itemcardapio a ser deletada</param>
        public void Delete(uint id)
        {
            var itemcardapio = context.Itemcardapios.Find(id);
            if (itemcardapio != null)
            {
                context.Itemcardapios.Remove(itemcardapio);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Edita uma Itemcardapio existente no banco de dados.
        /// </summary>
        /// <param name="itemcardapio">Itemcardapio com as informações atualizadas</param>
        public void Edit(Itemcardapio itemcardapio)
        {
            context.Update(itemcardapio);
            context.SaveChanges();
        }

        /// <summary>
        /// Obtém uma Itemcardapio pelo seu ID.
        /// </summary>
        /// <returns>Itemcardapio correspondente ao ID fornecido, ou null se não encontrado</returns>
        public Itemcardapio? Get(uint id)
        {
            return context.Itemcardapios.Find(id);
        }

        /// <summary>
        /// Obtém todas as Itemcardapios do banco de dados.
        /// </summary>
        /// <returns>Uma coleção de todas as Itemcardapios</returns>
        public IEnumerable<Itemcardapio> GetAll()
        {
            return context.Itemcardapios.AsNoTracking();
        }
    }
}
