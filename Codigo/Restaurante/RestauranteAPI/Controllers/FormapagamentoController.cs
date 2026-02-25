using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormapagamentoController : ControllerBase
    {
        private readonly IFormapagamentoService _formaPagamentoService;
		private readonly IMapper _mapper;

		public FormapagamentoController(IFormapagamentoService formaPagamentoService, IMapper mapper)
		{
			_formaPagamentoService = formaPagamentoService;
			_mapper = mapper;
		}

        // GET: api/<FormapagamentoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaFormasPagamento = _formaPagamentoService.GetAll();
            if (listaFormasPagamento == null)
                return NotFound();
            return Ok(listaFormasPagamento);
        }

         // GET api/<FormapagamentoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var formaPagamento = _formaPagamentoService.Get(id);
            if (formaPagamento == null)
                return NotFound();
            return Ok(formaPagamento);
        }

         // POST api/<FormapagamentoController>
        [HttpPost]
        public ActionResult Post([FromBody] FormapagamentoViewModel formaPagamentoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("DADOS INVÁLIDOS");
            Formapagamento formaPagamento = _mapper.Map<Formapagamento>(formaPagamentoViewModel);
            _formaPagamentoService.Create(formaPagamento);
            return Ok();
        }

            // PUT api/<FormapagamentoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] FormapagamentoViewModel formaPagamentoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("DADOS INVÁLIDOS");
            Formapagamento formaPagamento = _mapper.Map<Formapagamento>(formaPagamentoViewModel);
            _formaPagamentoService.Update(id, formaPagamento);
            return Ok();
        }

         // DELETE api/<FormapagamentoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Formapagamento? formaPagamento = _formaPagamentoService.Get(id);

            if (formaPagamento == null)
                return NotFound();
            _formaPagamentoService.Delete(id);
            return Ok();
        }
    }
}