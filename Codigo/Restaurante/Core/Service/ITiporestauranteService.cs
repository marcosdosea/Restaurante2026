using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.Service
{
    public interface ITiporestauranteService
    {
        void Delete(uint id);

		void Edit(Tiporestaurante tipoRestaurante);

		uint Create(Tiporestaurante tipoRestaurante);
        
        Tiporestaurante? Get(uint id);

        IEnumerable<Tiporestaurante> GetAll();

      

    }
}
