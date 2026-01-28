using Microsoft.AspNetCore.Mvc;
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
        
        // GET: TiporestauranteController
        public ActionResult Index()
        {
            var tiposRestaurante = _tiporestauranteService.GetAll();
            var tiposRestauranteViewModel = _mapper.Map<List<TiporestauranteViewModel>>(tiposRestaurante);
            return View(tiposRestauranteViewModel);
        }


        // GET: TiporestauranteController/Details/5
        public ActionResult Details(int id)
        {
            var tipoRestaurante = _tiporestauranteService.Get((uint)id);
            var tipoRestauranteViewModel = _mapper.Map<TiporestauranteViewModel>(tipoRestaurante);
            return View(tipoRestauranteViewModel);
        }

        // GET: TiporestauranteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiporestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TiporestauranteViewModel tiporestauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoRestaurante = _mapper.Map<Core.Tiporestaurante>(tiporestauranteViewModel);
                _tiporestauranteService.Create(tipoRestaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TiporestauranteController/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoRestaurante = _tiporestauranteService.Get((uint)id);
            var tipoRestauranteViewModel = _mapper.Map<TiporestauranteViewModel>(tipoRestaurante);
            return View(tipoRestauranteViewModel);
        }

        // POST: TiporestauranteController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TiporestauranteViewModel tiporestauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoRestaurante = _mapper.Map<Core.Tiporestaurante>(tiporestauranteViewModel);
                _tiporestauranteService.Edit(tipoRestaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TiporestauranteController/Delete/5
        public ActionResult Delete(int id)
        {
            var tipoRestaurante = _tiporestauranteService.Get((uint)id);
            var tipoRestauranteViewModel = _mapper.Map<TiporestauranteViewModel>(tipoRestaurante);
            return View(tipoRestauranteViewModel);
        }

        // POST: TiporestauranteController/Delete/5

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,TiporestauranteViewModel tiporestauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoRestaurante = _mapper.Map<Core.Tiporestaurante>(tiporestauranteViewModel);
                _tiporestauranteService.Delete((uint)id);
            }
            return RedirectToAction(nameof(Index));
        }


	}
}
