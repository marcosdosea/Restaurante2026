using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoService pedidoService;
        private readonly IMapper mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            this.pedidoService = pedidoService;
            this.mapper = mapper;
        }

        // GET: PedidoController
        public IActionResult Index()
        {
            var listaPedidos = pedidoService.GetAll();
            return View(listaPedidos);
        }

          // GET:PedidoController/Details/5
        
        public ActionResult Details(uint id)
        {
            var pedido = pedidoService.Get(id);
            PedidoViewModel pedidoViewModel = mapper.Map<PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }


        // GET:PedidoController/Create
        
       
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                var pedido = mapper.Map<Core.Pedido>(pedidoViewModel);
                pedidoService.Create(pedido);
            }
            return RedirectToAction(nameof(Index));
        }


         // GET: PedidoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var pedido = pedidoService.Get(id);
            PedidoViewModel pedidoViewModel = mapper.Map<PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }


        // POST: PedidoController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                var pedido = mapper.Map<Core.Pedido>(pedidoViewModel);
                pedidoService.Edit(pedido);
            }
            return RedirectToAction(nameof(Index));
        }


          // GET:PedidoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var pedido = pedidoService.Get(id);
            PedidoViewModel pedidoViewModel = mapper.Map<PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }

        // POST: PedidoController/Delete/5

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id,PedidoViewModel pedidoViewModel)
        {
            var pedido = mapper.Map<Core.Pedido>(pedidoViewModel);
            pedidoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}