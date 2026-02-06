using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class RestauranteDTO
    {
        public uint Id { get; set; }
        public string Cnpj { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
    }
}
