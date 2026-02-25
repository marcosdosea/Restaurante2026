using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiporestauranteiController : ControllerBase
    {
        
        private readonly ITiporestauranteService _tiporestauranteService;
        private readonly IMapper _mapper;

        public TiporestauranteController(ITiporestauranteService tipoRestauranteService, IMapper mapper)
        {
            _tiporestauranteService = tipoRestauranteService;
            _mapper = mapper;
        }


        // GET: api/<TiporestauranteController>
        [HttpGet]

        public ActionResult Get()
        {
            var listaTipoRestaurante = _tiporestauranteService.GetAll();
            if (listaTipoRestaurante == null)
                return NotFound();
            return Ok(listaTipoRestaurante);
        }

         // GET api/<TiporestauranteController>/5     
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var tipoRestaurante = _tiporestauranteService.Get(id);
            if (tipoRestaurante == null)
                return NotFound();
            return Ok(tipoRestaurante);
        }

         // POST api/<TiporestauranteController>
        [HttpPost]
        public ActionResult Post([FromBody] TiporestauranteViewModel tipoRestauranteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("DADOS INVÁLIDOS");
            Tiporestaurante tipoRestaurante = _mapper.Map<Tiporestaurante>(tipoRestauranteViewModel);
            _tiporestauranteService.Create(tipoRestaurante);
            return Ok();
        }

         // PUT api/<TiporestauranteController>/5   
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] TiporestauranteViewModel tipoRestauranteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("DADOS INVÁLIDOS");
            Tiporestaurante tipoRestaurante = _mapper.Map<Tiporestaurante>(tipoRestauranteViewModel);
            _tiporestauranteService.Update(id, tipoRestaurante);
            return Ok();
        }

         // DELETE api/<TiporestauranteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            Tiporestaurante? tipoRestaurante = _tiporestauranteService.Get(id);

            if (tipoRestaurante == null)
                return NotFound();
            _tiporestauranteService.Delete(id);
            return Ok();

        }
    }
}