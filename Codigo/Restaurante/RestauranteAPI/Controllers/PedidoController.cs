using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService pedidoService;
        private readonly IMapper mapper;
        private readonly IFuncionarioService funcionarioService;
        private readonly IAtendimentoService atendimentoService;

        public PedidoController(IPedidoService pedidoService, IMapper mapper, IFuncionarioService funcionarioService, IAtendimentoService atendimentoService)
        {
            this.pedidoService = pedidoService;
            this.mapper = mapper;
            this.funcionarioService = funcionarioService;
            this.atendimentoService = atendimentoService;
        }


        
        // GET: api/<PedidoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPedidos = pedidoService.GetAll();
            if (listaPedidos == null)
                return NotFound();
            return Ok(listaPedidos);
        }


         // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var pedido = pedidoService.Get(id);
            if (pedido == null)
                return NotFound();
            return Ok(pedido);
        }


        // POST api/<RestaurantesController>
        [HttpPost]
        public ActionResult Post([FromBody] PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("DADOS INVÁLIDOS");
            Pedido pedido = mapper.Map<Pedido>(pedidoViewModel);
            pedidoService.Create(pedido);
            return Ok();
        }



         // PUT api/<RestaurantesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("DADOS INVÁLIDOS");
            Pedido pedido = mapper.Map<Pedido>(pedidoViewModel);
            if(pedido == null)
                return NotFound();
            pedidoService.Edit(id, pedido);
            return Ok();
        }


         // DELETE api/<RestaurantesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Pedido? pedido = pedidoService.Get(id);

            if (pedido == null)
                return NotFound();
            pedidoService.Delete(id);
            return Ok();
        }



    }




    
}









