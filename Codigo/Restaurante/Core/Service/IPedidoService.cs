using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.DTO;

namespace Core.Service
{
    public interface IPedidoService
    {
        uint Create(Pedido pedido);

        void Edit(Pedido pedido);

        void Delete(uint id);

        Pedido? Get(uint id);

        IEnumerable<PedidoDTO> GetAll();
    }
}