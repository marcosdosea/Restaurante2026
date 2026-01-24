using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using ZstdSharp.Unsafe;

namespace Service
{
    public class RestauranteService : IRestauranteService
    {
        private readonly RestauranteContext _context;

        public RestauranteService(RestauranteContext context)
        {   
            _context = context;
        }

        /// <summary>
        /// Insere um novo restaurante no banco de dados
        /// </summary>
        /// <param name="restaurante"></param>
        /// <returns></returns>
        public uint Create(Restaurante restaurante)
        {
            _context.Add(restaurante);
            _context.SaveChanges();
            return restaurante.Id;
        }

        /// <summary>
        /// deleta um restaurante do banco de dados com base no seu id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var _restaurante = _context.Restaurantes.Find(id);
            if (_restaurante != null)
            {
                _context.Restaurantes.Remove(_restaurante);
                _context.SaveChanges();
            }
            
        }

        /// <summary>
        /// Edita as informaçoes de um restaurante 
        /// </summary>
        /// <param name="restaurante"></param>
        /// <exception cref="ServiceException"></exception>
        public void Edit(Restaurante restaurante)
        {
            if (restaurante != null)
            {
                _context.Update(restaurante);
                _context.SaveChanges();
            }
            
        }

        /// <summary>
        /// busca um restaurante pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurante? Get(uint id)
        {
            return _context.Restaurantes.Find(id);
        }

        /// <summary>
        /// retorna todos os restaurantes cadastrado no banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Restaurante> GetAll()
        {
            return _context.Restaurantes.AsNoTracking();
        }
    }

}
