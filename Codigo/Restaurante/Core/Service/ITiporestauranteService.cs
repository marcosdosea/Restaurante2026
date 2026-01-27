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
        bool Remover(uint id);

		bool Editar(uint id, string nome);

		uint Inserir(Tiporestaurante tipoRestaurante);

        TiporestauranteDTO? Obter(uint id);

        IEnumerable<TiporestauranteDTO> ObterTodos();

        IEnumerable<RestaurantePorTipoDTO>? ObterTodosRestaurantesPeloId(uint id);

    }
}
