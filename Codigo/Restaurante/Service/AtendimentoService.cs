using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly RestauranteContext context;

        public AtendimentoService(RestauranteContext context)
        {
            this.context = context;
    }
        /// <summary>
        /// Insere um novo atendimento no banco de dados
        /// </summary>
        /// <param name="atendimento"></param>
        /// <returns></returns>
        public uint Create(Atendimento atendimento)
        {
            context.Atendimentos.Add(atendimento);
            context.SaveChanges();
            return atendimento.Id;
        }

        /// <summary>
        /// deleta um atendimento do banco de dados com base no seu id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var atendimento = context.Atendimentos.Find(id);
            if (atendimento != null)
            {
                context.Atendimentos.Remove(atendimento );
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Edita as informaçoes de um atendimento 
        /// </summary>
        /// <param name="atendimento"></param>
        /// <exception cref="ServiceException"></exception>
        public void Edit(Atendimento atendimento)
        {

            context.Update(atendimento);
            context.SaveChanges();
        }

        /// <summary>
        /// busca um atendimento pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Atendimento? Get(uint id)
        {
            return context.Atendimentos.Find(id);
        }

        /// <summary>
        /// retorna todos os atendimentos cadastrados no banco de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AtendimentoDTO> GetAll()
        {

            return context.Atendimentos.AsNoTracking().Select(a => new AtendimentoDTO
            {

                Id = a.Id,
                DataHoraInicio = a.DataHoraInicio,
                IdMesa = a.IdMesa,
                Status = a.Status,
            });
        }
    }
}
