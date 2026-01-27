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
        private readonly IRestauranteService restauranteService;
        private readonly IMapper mapper;

        public RestauranteController(IRestauranteService restauranteService, IMapper mapper)
        {
            this.restauranteService = restauranteService;
            this.mapper = mapper;
        }

        // GET: RestauranteController
        public ActionResult Index()
        {
            var listaRestaurantes = restauranteService.GetAll();
            var listaRestaurantesViewModel = mapper.Map<List<RestauranteViewModel>>(listaRestaurantes);
            return View(listaRestaurantesViewModel);
        }

        // GET: RestauranteController/Details/5
        public ActionResult Details(uint id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
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
                
                var restaurante = mapper.Map<Restaurante>(restauranteViewModel);
                restauranteService.Create(restaurante);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RestauranteController/Edit/5
        public ActionResult Edit(uint id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, RestauranteViewModel restauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurante = mapper.Map<Restaurante>(restauranteViewModel);
                restauranteService.Edit(restaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RestauranteController/Delete/5
        public ActionResult Delete(uint id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RestauranteViewModel restauranteViewModel)
        {
            restauranteService.Delete(restauranteViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
