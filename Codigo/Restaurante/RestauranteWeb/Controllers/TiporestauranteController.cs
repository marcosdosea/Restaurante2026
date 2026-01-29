using Microsoft.AspNetCore.Mvc;
using Service;
using Core;
using Core.Service;
using AutoMapper;
using RestauranteWeb.Models;
namespace RestauranteWeb.Controllers
{
    public class TiporestauranteController : Controller
    {

        private readonly ITiporestauranteService _tiporestauranteService;
        private readonly IMapper _mapper;

        public TiporestauranteController(ITiporestauranteService tipoRestauranteService, IMapper mapper)
        {
            _tiporestauranteService = tipoRestauranteService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var listaTiposRestaurantes = _tiporestauranteService.ObterTodos();
            var listaTiposRestaurantesModel = _mapper.Map<List<TiporestauranteModel>>(listaTiposRestaurantes);
            return View(listaTiposRestaurantesModel);
        }

        // GET: TipoRestaurante/Detalhes/5
        public IActionResult Detalhes(uint id)
        {
            var tipoRestauranteDto = _tiporestauranteService.Obter(id);
            if (tipoRestauranteDto == null)
            {
                return NotFound();
            }
            var tipoRestauranteModel = _mapper.Map<TiporestauranteModel>(tipoRestauranteDto);
            return View(tipoRestauranteModel);
        }

        // GET: TipoRestaurante/Criar
        public ActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: TipoRestaurante/Criar
        public IActionResult Criar(TiporestauranteModel tipoRestauranteModel)
        {
            if (ModelState.IsValid)
            {
                var tipoRestaurante = _mapper.Map<Tiporestaurante>(tipoRestauranteModel);
                _tiporestauranteService.Inserir(tipoRestaurante);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRestauranteModel);
        }

        //GET : TipoRestaurante/Editar/5
        public ActionResult Editar(int id)
        {
            var tipoRestauranteDto = _tiporestauranteService.Obter((uint)id);
            if (tipoRestauranteDto == null)
            {
                return NotFound();
            }
            var tipoRestauranteModel = _mapper.Map<TiporestauranteModel>(tipoRestauranteDto);
            return View(tipoRestauranteModel);
        }

        // POST : TipoRestaurante/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Editar(int id, TiporestauranteModel tipoRestauranteModel)
        {
            if (ModelState.IsValid)
            {   
                _tiporestauranteService.Editar((uint)id, tipoRestauranteModel.Nome);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRestauranteModel);
        }


		// GET: TipoRestaurante/Remover/5

        public ActionResult Remover(int id)
        {
            var tipoRestauranteDto = _tiporestauranteService.Obter((uint)id);
            if (tipoRestauranteDto == null)
            {
                return NotFound();
            }
            var tipoRestauranteModel = _mapper.Map<TiporestauranteModel>(tipoRestauranteDto);
            return View(tipoRestauranteModel);
		}

		// POST: TipoRestaurante/Remover/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoverConfirmado(int id)
        {
            _tiporestauranteService.Remover((uint)id);
            return RedirectToAction(nameof(Index));
		}




		// GET: TipoRestaurante/Restaurantes/5
		public IActionResult Restaurantes(uint id)
		{
			var restaurantesPorTipoDto = _tiporestauranteService.ObterTodosRestaurantesPeloId(id);

			if (restaurantesPorTipoDto == null)
				return NotFound();

			var restaurantesModel = _mapper.Map<List<RestaurantePorTipoModel>>(restaurantesPorTipoDto);

			ViewBag.TipoRestauranteId = id;

			return View(restaurantesModel);
		}




	}
}
