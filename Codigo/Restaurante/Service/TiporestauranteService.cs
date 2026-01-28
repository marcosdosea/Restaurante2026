using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class TiporestauranteService : ITiporestauranteService
    {
        private readonly RestauranteContext _context;
        public TiporestauranteService(RestauranteContext context)
        {
            _context = context;
		}


        /// <summary>
        /// Cria um novo tipo de restaurante no banco de dados
        /// </summary>
        /// <returns>id gerado para o tipoRestaurante</returns>

        public uint Create(Tiporestaurante tipoRestaurante)
        {
            _context.Tiporestaurantes.Add(tipoRestaurante);
            _context.SaveChanges();
            return tipoRestaurante.Id;
            
        }

        /// <summary>
        /// Remove um tipo de restaurante do banco de dados
        /// </summary>
        

        public void Delete(uint id)
        {
            var tipoRestaurante = _context.Tiporestaurantes.Find(id);
            if (tipoRestaurante != null)
            {
                _context.Tiporestaurantes.Remove(tipoRestaurante);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza um tipo de restaurante no banco de dados
        /// </summary>
       

        public void Edit(Tiporestaurante tipoRestaurante)
        {
            var tiporestaurante = _context.Tiporestaurantes.Find(tipoRestaurante.Id);
            if (tiporestaurante != null)
            {
                _context.Tiporestaurantes.Update(tipoRestaurante);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Obtém um tipo de restaurante pelo seu ID
        /// </summary>
        
        public Tiporestaurante? Get(uint id)
        {
            var tipoRestaurante = _context.Tiporestaurantes.Find(id);
            return tipoRestaurante;
        }

        /// <summary>
        /// Obtém todos os tipos de restaurante
        /// </summary>
        public IEnumerable<Tiporestaurante> GetAll()
        {
            return _context.Tiporestaurantes.AsNoTracking();
        }
    }
}



