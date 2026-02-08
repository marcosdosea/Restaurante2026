using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;
using Service;

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
        public ActionResult Details(uint id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // GET: RestauranteController/Create
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


        [HttpPost]
        public IActionResult GetByPage()
        {
            // Pegando parâmetros que o DataTable envia
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            // Aqui você busca os dados do banco
            var query = restauranteService.GetAll(); // exemplo

            var recordsTotal = query.Count();

            var data = query.Skip(skip).Take(pageSize).ToList();

            // Retorno no formato que o DataTable espera
            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            });
        }
    }
}
