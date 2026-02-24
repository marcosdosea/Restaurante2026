using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class RestauranteController : Controller
    {
        private readonly ITiporestauranteService tiporestauranteService;
        private readonly IRestauranteService restauranteService;
        private readonly IMapper mapper;

        public RestauranteController(ITiporestauranteService tiporestauranteService, IRestauranteService restauranteService, IMapper mapper)
        {
            this.tiporestauranteService = tiporestauranteService;
            this.restauranteService = restauranteService;
            this.mapper = mapper;
        }

        // GET: RestauranteController
        public ActionResult Index()
        {
            var listaRestaurantes = restauranteService.GetAll();
            return View(listaRestaurantes);
        }

        // GET: RestauranteController/Details/5
        [Authorize]
        public ActionResult Details(uint id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // GET: RestauranteController/Create
        [Authorize]
        public ActionResult Create()
        {   
            RestauranteViewModel restauranteModel = new();
            IEnumerable<Tiporestaurante> listatiposrestaurante = tiporestauranteService.GetAll();
            restauranteModel.ListaTiposRestaurantes = new SelectList(listatiposrestaurante,"Id", "Nome", null);
            return View(restauranteModel);
        }

        // POST: RestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
        public ActionResult Edit(uint id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);

            IEnumerable<Tiporestaurante> listatiposrestaurante = tiporestauranteService.GetAll();
            restauranteViewModel.ListaTiposRestaurantes = new SelectList(listatiposrestaurante, "Id", "Nome", null);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
        public ActionResult Delete(uint id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(RestauranteViewModel restauranteViewModel)
        {
            restauranteService.Delete(restauranteViewModel.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
