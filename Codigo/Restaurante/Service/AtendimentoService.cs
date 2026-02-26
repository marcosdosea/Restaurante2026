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
            var mesa = context.Mesas.Find(atendimento.IdMesa);
            if (mesa is not null)
            {
                atendimento.IdMesaNavigation = mesa;
            }
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
                context.Atendimentos.Remove(atendimento);
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
            var mesa = context.Mesas.Find(atendimento.IdMesa);
            if (mesa is not null)
            {
                atendimento.IdMesaNavigation = mesa;
            }
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
        /// Finaliza um atendimento, calculando o total da conta, serviço e desconto, e atualizando o status para "F" (finalizado) se o pagamento for suficiente.
        /// </summary>
        /// <param name="idMesa"></param>
        /// <returns></returns>
        public Atendimento? FinalizarAtendimento(uint idMesa)
        {
            var atendimento = context.Atendimentos
                .FirstOrDefault(a => a.IdMesa == (uint)idMesa && a.Status == "I");

            if (atendimento == null) return null;

            atendimento.TotalConta = atendimento.Pedidos
                .Where(p => p.Status != "C")
                .Sum(p => p.Pedidoitemcardapios.Sum(pic => pic.Quantidade * (pic.IdItemCardapioNavigation.Preco ?? 0)));

            atendimento.TotalServico = atendimento.TotalConta * 0.10m;
            atendimento.Total = (atendimento.TotalConta + atendimento.TotalServico) - atendimento.TotalDesconto;

            if (atendimento.Pagamentos.Sum(p => p.Valor) >= atendimento.Total)
            {
                atendimento.Status = "F";
                atendimento.DataHoraFim = DateTime.Now;
            }

            context.SaveChanges();
            return atendimento;
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
        public IEnumerable<AtendimentoDTO> GetByRestaurante(uint idRestaurante)
        {
            return context.Atendimentos
                .Include(a => a.IdMesaNavigation)
                .Where(a => a.IdMesaNavigation.IdRestaurante == idRestaurante)
                .AsNoTracking()
                .Select(a => new AtendimentoDTO
                {
                    Id = a.Id,
                    DataHoraInicio = a.DataHoraInicio,
                    IdMesa = a.IdMesa,
                    Status = a.Status,
                });
        }
    }
}
