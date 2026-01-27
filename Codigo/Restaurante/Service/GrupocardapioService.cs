using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class GrupocardapioService : IGrupocardapioService
    {
        private readonly RestauranteContext _context;

        public GrupocardapioService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(GrupocardapioDTO grupoDto)
        {
            var grupo = new Grupocardapio
            {
                Nome = grupoDto.Nome
            };
            _context.Add(grupo);
            _context.SaveChanges();
            return grupo.Id;
        }

        public void Delete(uint id)
        {
            var grupo = _context.Grupocardapios.Find(id);
            if (grupo != null)
            {
                _context.Grupocardapios.Remove(grupo);
                _context.SaveChanges();
            }
        }

        public void Edit(GrupocardapioDTO grupoDto)
        {
            var grupo = _context.Grupocardapios.Find(grupoDto.Id);
            if (grupo != null)
            {
                grupo.Nome = grupoDto.Nome;
                _context.Update(grupo);
                _context.SaveChanges();
            }
        }

        public GrupocardapioDTO Get(uint id)
        {
            var grupo = _context.Grupocardapios.Find(id);
            if (grupo == null) return null;

            return new GrupocardapioDTO
            {
                Id = grupo.Id,
                Nome = grupo.Nome
            };
        }

        public IEnumerable<GrupocardapioDTO> GetAll()
        {
            return _context.Grupocardapios
                .AsNoTracking()
                .Select(g => new GrupocardapioDTO
                {
                    Id = g.Id,
                    Nome = g.Nome
                })
                .ToList();
        }
    }
}