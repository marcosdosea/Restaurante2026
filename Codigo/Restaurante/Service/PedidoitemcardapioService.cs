using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class PedidoitemcardapioService : IPedidoitemcardapio
    {
        private readonly RestauranteContext context;

        public PedidoitemcardapioService(RestauranteContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Insere um novo pedido item cardápio no banco de dados
        /// </summary>
        /// <param name="pedidoitemcardapio "></param>
        /// <returns></returns>
        public uint Create(Pedidoitemcardapio pedidoitemcardapio)
        {
            var pedido = context.Pedidos.Find(pedidoitemcardapio.IdPedido);
            if (pedido is not null)
            {
                pedidoitemcardapio.IdPedidoNavigation = pedido;
            }
            var itemcardapio = context.Itemcardapios.Find(pedidoitemcardapio.IdItemCardapio);
            if (itemcardapio is not null)
            {
                pedidoitemcardapio.IdItemCardapioNavigation = itemcardapio;
            }
            context.Pedidoitemcardapios.Add(pedidoitemcardapio);
            context.SaveChanges();
            return pedidoitemcardapio.IdPedido;

        }

        public void Edit(Pedidoitemcardapio pedidoitemcardapio)
        {
            var pedido = context.Pedidos.Find(pedidoitemcardapio.IdPedido);
            if (pedido is not null)
            {
                pedidoitemcardapio.IdPedidoNavigation = pedido;
            }
            var itemcardapio = context.Itemcardapios.Find(pedidoitemcardapio.IdItemCardapio);
            if (itemcardapio is not null)
            {
                pedidoitemcardapio.IdItemCardapioNavigation = itemcardapio;
            }
            context.Pedidoitemcardapios.Update(pedidoitemcardapio);
            context.SaveChanges();
        }

        public void Delete(uint id)
        {
            var pedido = context.Pedidos.Find(id);

            var listaitenspedidocompedidoid = context.Pedidoitemcardapios.Where(p => p.IdPedido == id).ToList();
             foreach (var item in listaitenspedidocompedidoid)
            {
                context.Pedidoitemcardapios.Remove(item);
            }
            if (pedido is not null)
            {

                context.Pedidos.Remove(pedido);
                context.SaveChanges();
            }
        }

        public IEnumerable<Pedidoitemcardapio> Get(uint id)
        {
            var listapedidoitemcardapio = context.Pedidoitemcardapios.Where(p => p.IdPedido == id).ToList();
            return listapedidoitemcardapio;
        }

        public IEnumerable<Pedidoitemcardapio> GetAll()
        {
            var listapedidoitemcardapio = context.Pedidoitemcardapios.ToList();
            return listapedidoitemcardapio;
        }
    }
}