using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class PedidoService : IPedidoService
    {
        private readonly RestauranteContext _context;
        public PedidoService(RestauranteContext context)
        {
            _context = context;
		}


        /// <summary>
        /// Cria um novo Pedido no banco de dados
        /// </summary>
        /// <returns>id gerado para o tipoRestaurante</returns>

        public uint Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido.Id;
            
        }

        /// <summary>
        /// Remove um Pedido do banco de dados
        /// </summary>
        

        public void Delete(uint id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza um Pedido no banco de dados
        /// </summary>
       

        public void Edit(Pedido pedido)
        { 
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
            
        }

        /// <summary>
        /// Obtém um Pedido pelo seu ID
        /// </summary>
        
        public Pedido? Get(uint id)
        {
            var pedido = _context.Pedidos.Find(id);
            return pedido;
        }

        /// <summary>
        /// Obtém todos os Pedidos
        /// </summary>
        public IEnumerable<PedidoDTO> GetAll()
        {
            return _context.Pedidos.AsNoTracking().Select(r => new PedidoDTO
            {
                Id = r.Id,
                DataHoraSolicitacao = r.DataHoraSolicitacao,
                DaaHoraAtendimento = r.DaaHoraAtendimento,
                IdAtendimento = r.IdAtendimento,
                IdGarcom = r.IdGarcom,
                Status = r.Status
            });
        }
    }
}