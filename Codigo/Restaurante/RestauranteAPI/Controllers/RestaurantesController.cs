using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {

        private readonly ITiporestauranteService tiporestauranteService;
        private readonly IRestauranteService restauranteService;
        private readonly IMapper mapper;

        public RestaurantesController(ITiporestauranteService tiporestauranteService, IRestauranteService restauranteService, IMapper mapper)
        {
            this.tiporestauranteService = tiporestauranteService;
            this.restauranteService = restauranteService;
            this.mapper = mapper;
        }

        // GET: api/<RestaurantesController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaRestaurantes = restauranteService.GetAll();
            if (listaRestaurantes == null)
                return NotFound();
            return Ok(listaRestaurantes);
        }

        // GET api/<RestaurantesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(uint id)
        {
            var restaurante = restauranteService.Get(id);
            if (restaurante == null)
                return NotFound();
            return Ok(restaurante);
        }

        // POST api/<RestaurantesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<RestaurantesController>/5
        [HttpPut("{id}")]
        public void Put(uint id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaurantesController>/5
        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
        }
    }
}
