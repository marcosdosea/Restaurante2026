using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class FormapagamentoService : IFormapagamento
    {

		private readonly RestauranteContext _context;
		public FormapagamentoService(RestauranteContext context)
		{
			_context = context;
		}
		/// <summary>
		/// Cria uma nova forma de pagamento no banco de dados
		/// </summary>
		/// <returns>id gerado para a forma de pagamento </returns>
		public uint Create(Formapagamento formaPagamento)
        {
            _context.Formapagamentos.Add(formaPagamento);
            _context.SaveChanges();
            return formaPagamento.Id;
            

		}


		/// <summary>
		/// Remove uma forma de pagamento do banco de dados
		/// </summary>
		public void Delete(uint id)
        {
            var formaPagamento = _context.Formapagamentos.Find(id);
            if(formaPagamento != null)
            {
                _context.Formapagamentos.Remove(formaPagamento);
                _context.SaveChanges();
			}
        }

		/// <summary>
		/// Atualiza uma forma de pagamento no banco de dados
		/// </summary>
		public void Edit(Formapagamento formaPagamento)
        {
            _context.Formapagamentos.Update(formaPagamento);
            _context.SaveChanges();
        }


		/// <summary>
		/// Obtém uma forma de pagamento pelo seu ID
		/// </summary>

		public Formapagamento? Get(uint id)
        {
            var formaPagamento = _context.Formapagamentos.Find(id);
            _context.SaveChanges();
            return formaPagamento;
        }

		/// <summary>
		/// Obtém todos as formas de pagamento
		/// </summary>

		public IEnumerable<Formapagamento> GetAll()
        {
            return _context.Formapagamentos.AsNoTracking();
        }
    }
}
