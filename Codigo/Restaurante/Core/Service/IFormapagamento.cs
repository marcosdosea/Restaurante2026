using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IFormapagamento
    {
		void Delete(uint id);

		void Edit(Formapagamento formaPagamento);

		uint Create(Formapagamento formaPagamento);

		Formapagamento? Get(uint id);

		IEnumerable<Formapagamento> GetAll();
	}
}
