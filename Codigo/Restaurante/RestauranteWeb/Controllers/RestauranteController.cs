using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class RestauranteController : Controller
    {
        private readonly IRestauranteService _restauranteService;
        private readonly IMapper _mapper;

        public RestauranteController(IRestauranteService restauranteService, IMapper mapper)
        {
            this._restauranteService = restauranteService;
            this._mapper = mapper;
        }

        // GET: RestauranteController
        public ActionResult Index()
        {
            var listaRestaurantes = _restauranteService.GetAll().ToList();
            var listaRestaurantesViewModel = _mapper.Map<List<RestauranteViewModel>>(listaRestaurantes);
            return View(listaRestaurantesViewModel);
        }

        // GET: RestauranteController/Details/5
        public ActionResult Details(uint id)
        {
            var restaurante = _restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = _mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // GET: RestauranteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestauranteViewModel restauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurante = _mapper.Map<Restaurante>(restauranteViewModel);
                _restauranteService.Create(restaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RestauranteController/Edit/5
        public ActionResult Edit(uint id)
        {
            var restaurante = _restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = _mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, RestauranteViewModel restauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurante = _mapper.Map<Restaurante>(restauranteViewModel);
                _restauranteService.Edit(restaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RestauranteController/Delete/5
        public ActionResult Delete(uint id)
        {
            var restaurante = _restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = _mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, IFormCollection collection)
        {
            _restauranteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
