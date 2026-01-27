using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class RestauranteService : IRestauranteService
    {
        private readonly RestauranteContext context;

        public RestauranteService(RestauranteContext context)
        {   
            this.context = context;
        }

        /// <summary>
        /// Insere um novo restaurante no banco de dados
        /// </summary>
        /// <param name="restaurante"></param>
        /// <returns></returns>
        public uint Create(Restaurante restaurante)
        {
            context.Restaurantes.Add(restaurante);
            context.SaveChanges();
            return restaurante.Id;
        }

        /// <summary>
        /// deleta um restaurante do banco de dados com base no seu id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var restaurante = context.Restaurantes.Find(id);
            if (restaurante != null)
            {
                context.Restaurantes.Remove(restaurante);
                context.SaveChanges();
            }
            
        }

        /// <summary>
        /// Edita as informaçoes de um restaurante 
        /// </summary>
        /// <param name="restaurante"></param>
        /// <exception cref="ServiceException"></exception>
        public void Edit(Restaurante restaurante)
        {
            context.Update(restaurante);
            context.SaveChanges();
        }

        /// <summary>
        /// busca um restaurante pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurante? Get(uint id)
        {
            return context.Restaurantes.Find(id);
        }

        /// <summary>
        /// retorna todos os restaurantes cadastrado no banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Restaurante> GetAll()
        {
            return context.Restaurantes.AsNoTracking();
        }
    }

}
