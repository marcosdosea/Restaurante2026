using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class ItemcardapioController : Controller
    {
        private readonly IItemcardapioService ItemcardapioService;
        private readonly IMapper mapper;
        public ItemcardapioController(IItemcardapioService ItemcardapioService, IMapper mapper)
        {
            this.ItemcardapioService = ItemcardapioService;
            this.mapper = mapper;
        }
        // GET: ItemcardapioController
        public ActionResult Index()
        {
            var listaItemcardapio = ItemcardapioService.GetAll();
            var listaItemcardapioViewModel = mapper.Map<List<ItemcardapioViewModel>>(listaItemcardapio);
            return View(listaItemcardapioViewModel);
        }

        // GET: ItemcardapioController/Details/5
        public ActionResult Details(uint id)
        {
            var itemcardapio = ItemcardapioService.Get(id);
            var itemcardapioViewModel = mapper.Map<ItemcardapioViewModel>(itemcardapio);
            return View(itemcardapioViewModel);
        }

        // GET: ItemcardapioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemcardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemcardapioViewModel itemcardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                var itemcardapio = mapper.Map<Itemcardapio>(itemcardapioViewModel);
                ItemcardapioService.Create(itemcardapio);
                
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemcardapioController/Edit/5
        public ActionResult Edit(uint id)
        {
            var itemcardapio = ItemcardapioService.Get(id);
            var itemcardapioViewModel = mapper.Map<ItemcardapioViewModel>(itemcardapio);
            return View(itemcardapioViewModel);
        }

        // POST: ItemcardapioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ItemcardapioViewModel itemcardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                var itemcardapio = mapper.Map<Itemcardapio>(itemcardapioViewModel);
                ItemcardapioService.Edit(itemcardapio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemcardapioController/Delete/5
        public ActionResult Delete(uint id)
        {
            var itemcardapio = ItemcardapioService.Get(id);
            var itemcardapioViewModel = mapper.Map<ItemcardapioViewModel>(itemcardapio);
            return View(itemcardapioViewModel);
        }

        // POST: ItemcardapioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ItemcardapioViewModel itemcardapioViewModel)
        {
            ItemcardapioService.Delete(itemcardapioViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
