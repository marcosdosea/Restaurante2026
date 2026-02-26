using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPedidoitemcardapio
    {
            uint Create(Pedidoitemcardapio pedidoitemcardapio);
    
            void Edit(Pedidoitemcardapio pedidoitemcardapio);
    
            void Delete(uint id);

            IEnumerable<Pedidoitemcardapio> Get(uint id);
    
            IEnumerable<Pedidoitemcardapio> GetAll();
    }
}
