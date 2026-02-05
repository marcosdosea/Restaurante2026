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
            var tiposRestauranteViewModel = _mapper.Map<List<FormapagamentoViewModel>>(tiposRestaurante);
            return View(tiposRestauranteViewModel);
        }


        // GET: TiporestauranteController/Details/5
        public ActionResult Details(uint id)
        {
            var tipoRestaurante = _tiporestauranteService.Get(id);
            var tipoRestauranteViewModel = _mapper.Map<FormapagamentoViewModel>(tipoRestaurante);
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
        public ActionResult Create(FormapagamentoViewModel tiporestauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoRestaurante = _mapper.Map<Core.Tiporestaurante>(tiporestauranteViewModel);
                _tiporestauranteService.Create(tipoRestaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TiporestauranteController/Edit/5
        public ActionResult Edit(uint id)
        {
            var tipoRestaurante = _tiporestauranteService.Get(id);
            var tipoRestauranteViewModel = _mapper.Map<FormapagamentoViewModel>(tipoRestaurante);
            return View(tipoRestauranteViewModel);
        }

        // POST: TiporestauranteController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormapagamentoViewModel tiporestauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoRestaurante = _mapper.Map<Core.Tiporestaurante>(tiporestauranteViewModel);
                _tiporestauranteService.Edit(tipoRestaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TiporestauranteController/Delete/5
        public ActionResult Delete(uint id)
        {
            var tipoRestaurante = _tiporestauranteService.Get(id);
            var tipoRestauranteViewModel = _mapper.Map<FormapagamentoViewModel>(tipoRestaurante);
            return View(tipoRestauranteViewModel);
        }

        // POST: TiporestauranteController/Delete/5

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id,FormapagamentoViewModel tiporestauranteViewModel)
        {
            var tipoRestaurante = _mapper.Map<Core.Tiporestaurante>(tiporestauranteViewModel);
            _tiporestauranteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


	}
}
