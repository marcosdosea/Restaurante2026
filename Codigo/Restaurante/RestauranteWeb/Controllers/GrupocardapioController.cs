using AutoMapper;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class GrupocardapioController : Controller
    {
        private readonly IGrupocardapioService _grupoService;
        private readonly IMapper _mapper;

        public GrupocardapioController(IGrupocardapioService grupoService, IMapper mapper)
        {
            _grupoService = grupoService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaDTO = _grupoService.GetAll();
            var listaModel = _mapper.Map<List<GrupocardapioViewModel>>(listaDTO);
            return View(listaModel);
        }

        public ActionResult Details(uint id)
        {
            var grupo = _grupoService.Get(id);
            if (grupo == null) return NotFound();
            var model = _mapper.Map<GrupocardapioViewModel>(grupo);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GrupocardapioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<GrupocardapioDTO>(model);
                _grupoService.Create(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public ActionResult Edit(uint id)
        {
            var grupo = _grupoService.Get(id);
            if (grupo == null) return NotFound();
            var model = _mapper.Map<GrupocardapioViewModel>(grupo);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, GrupocardapioViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<GrupocardapioDTO>(model);
                _grupoService.Edit(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public ActionResult Delete(uint id)
        {
            var grupo = _grupoService.Get(id);
            var model = _mapper.Map<GrupocardapioViewModel>(grupo);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(uint id)
        {
            _grupoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}