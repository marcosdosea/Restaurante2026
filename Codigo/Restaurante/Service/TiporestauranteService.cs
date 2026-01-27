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
		public bool Editar(uint id, string nome)
		{
			var tipoRestaurante = _context.Tiporestaurantes.Find(id);

			if (tipoRestaurante == null) return false;

			tipoRestaurante.Nome = nome;
			_context.SaveChanges();

			return true;
		}


		public uint Inserir(Tiporestaurante tipoRestaurante)
        {
            _context.Tiporestaurantes.Add(tipoRestaurante);
            _context.SaveChanges();
            return  tipoRestaurante.Id;


		}

        public TiporestauranteDTO? Obter(uint id)
        {
            var tiporestaurante = _context.Tiporestaurantes.Find(id);

            return (tiporestaurante == null) ? null : new TiporestauranteDTO
            {
                Id = tiporestaurante.Id,
                Nome = tiporestaurante.Nome
            };
            
        }

        public IEnumerable<TiporestauranteDTO> ObterTodos()
        {
            return _context.Tiporestaurantes.OrderBy(tr=>tr.Nome).Select(tr => new TiporestauranteDTO
            {
                Id = tr.Id,
                Nome = tr.Nome
            }).ToList();
            
		}

        public IEnumerable<RestaurantePorTipoDTO>? ObterTodosRestaurantesPeloId(uint id)
        {
			var tipoexiste = _context.Tiporestaurantes.Any(tr => tr.Id == id);

			return (!tipoexiste) ? null :
                _context.Restaurantes
				.Where(r => r.IdTipoRestaurante == id)
				.OrderBy(r => r.Nome)
				.Select(r => new RestaurantePorTipoDTO
				{
					Id = r.Id,
					Nome = r.Nome,
					Cidade = r.Cidade,
					Estado = r.Estado,
					Telefone = r.Telefone1
				})
				.ToList();
		}

        public bool Remover(uint id)
        {
            var tipoRestaurante = _context.Tiporestaurantes.Find(id);

            if (tipoRestaurante == null) return false;
            
            _context.Tiporestaurantes.Remove(tipoRestaurante);
            _context.SaveChanges();
            return true;
            
		}
    }
}


