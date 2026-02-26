using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Service
{
    public class PagamentoService : IPagamentoService
    {
        private readonly RestauranteContext _context;

        public PagamentoService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(Pagamento pagamento)
        {

            pagamento.DataHora = DateTime.Now;
            _context.Pagamentos.Add(pagamento);


            var atendimento = _context.Atendimentos
                .Include(a => a.Pagamentos)
                .FirstOrDefault(a => a.Id == pagamento.IdAtendimento);

            if (atendimento != null)
            {

                var totalPago = atendimento.Pagamentos.Sum(p => p.Valor) + pagamento.Valor;

                if (totalPago >= atendimento.Total)
                {
                    atendimento.Status = "F"; 
                    atendimento.DataHoraFim = DateTime.Now;
                    _context.Atendimentos.Update(atendimento);
                }
            }

            _context.SaveChanges();
            return pagamento.Id;
        }

        public decimal GetTotalPago(uint idAtendimento)
        {
            return _context.Pagamentos
                .Where(p => p.IdAtendimento == idAtendimento)
                .Sum(p => p.Valor);
        }
    }
}