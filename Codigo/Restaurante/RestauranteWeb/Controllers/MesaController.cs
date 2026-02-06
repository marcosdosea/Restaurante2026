using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{

    public class MesaController : Controller
    {
        private readonly IMesaService MesaService;
        private readonly IMapper mapper;

        public MesaController(IMesaService mesaService, IMapper mapper)
        {
            MesaService = mesaService;
            this.mapper = mapper;
        }

        // GET: MesaController
        public ActionResult Index()
        {
            var listaMesas = MesaService.GetAll();
            var listaMesasViewModel = mapper.Map<List<MesaViewModel>>(listaMesas);
            return View(listaMesasViewModel);
        }

        // GET: MesaController/Details/5
        public ActionResult Details(int id)
        {
            var mesa = MesaService.Get(id);
            MesaViewModel mesaViewModel = mapper.Map<MesaViewModel>(mesa);
            return View(mesaViewModel);
        }

        // GET: MesaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MesaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var mesa = mapper.Map<Mesa>(collection);
                MesaService.Create(mesa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MesaController/Edit/5
        public ActionResult Edit(int id)
        {
            var mesa = MesaService.Get(id);
            var mesaViewModel = mapper.Map<MesaViewModel>(mesa);
            return View(mesaViewModel);
        }

        // POST: MesaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var mesa = mapper.Map<Mesa>(collection);
                mesa.Id = id;
                MesaService.Edit(mesa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MesaController/Delete/5
        public ActionResult Delete(int id)
        {
            var mesa = MesaService.Get(id);
            var mesaViewModel = mapper.Map<MesaViewModel>(mesa);
            return View(mesaViewModel);
        }

        // POST: MesaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                MesaService.Delete(MesaService.Get(id)!);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
