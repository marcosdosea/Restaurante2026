using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class RestaurantePorTipoDTO
    {
		public uint Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string? Cidade { get; set; }
		public string? Estado { get; set; }
		public string? Telefone { get; set; }
	}
}
