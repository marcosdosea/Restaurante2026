using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;
using Service;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class ItemcardapioController : Controller
    {
        private readonly IGrupocardapioService grupocardapioService;
        private readonly IRestauranteService restauranteService;
        private readonly IItemcardapioService ItemcardapioService;
        private readonly IMapper mapper;
        public ItemcardapioController(IItemcardapioService ItemcardapioService, IGrupocardapioService grupocardapioService, IRestauranteService restauranteService, IMapper mapper)
        {
            this.ItemcardapioService = ItemcardapioService;
            this.grupocardapioService = grupocardapioService;
            this.restauranteService = restauranteService;
            this.mapper = mapper;
        }

        private void CarregarAtivo()
        {
            ViewBag.StatusList = new SelectList(new[]
            {
                new { Value = 1 , Text = "DISPONIVEL" },
                new { Value = 0, Text = "INDISPONIVEL" },
            }, "Value", "Text");
        }
        private SelectList ObterRestaurantes()
        {
            IEnumerable<RestauranteDTO> listaRestaurantes = restauranteService.GetAll();
            return new SelectList(listaRestaurantes, "Id", "Nome", null);
        }   

        private SelectList ObterCardapios()
        {
            IEnumerable<GrupocardapioDTO> listaCardapios = grupocardapioService.GetAll();
            return new SelectList(listaCardapios, "Id", "Nome", null);
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
            itemcardapioViewModel.NomeRestaurante = itemcardapio?.IdRestauranteNavigation.Nome ?? "Desconhecido";
            return View(itemcardapioViewModel);
        }

        // GET: ItemcardapioController/Create
        public ActionResult Create()
        {
                ItemcardapioViewModel itemcardapioViewModel = new();
                itemcardapioViewModel.ListaRestaurantes = ObterRestaurantes();
                itemcardapioViewModel.ListaCardapios = ObterCardapios();
                CarregarAtivo();
            return View(itemcardapioViewModel);
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
            itemcardapioViewModel.ListaRestaurantes = ObterRestaurantes();
            itemcardapioViewModel.ListaCardapios = ObterCardapios();
            CarregarAtivo();
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
