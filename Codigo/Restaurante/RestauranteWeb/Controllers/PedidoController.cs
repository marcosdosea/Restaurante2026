using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RestauranteWeb.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IPedidoService pedidoService;
        private readonly IMapper mapper;
        private readonly IFuncionarioService funcionarioService;
        private readonly IAtendimentoService atendimentoService;

        public PedidoController(IPedidoService pedidoService, IMapper mapper, IFuncionarioService funcionarioService, IAtendimentoService atendimentoService)
        {
            this.pedidoService = pedidoService;
            this.mapper = mapper;
            this.funcionarioService = funcionarioService;
            this.atendimentoService = atendimentoService;
        }


        private void CarregarStatus()
        {

            /// S - SOLICITADO
            /// C - CANCELADO
            /// A - ATENDIDO
            ViewBag.StatusList = new SelectList(new[]
            {
                new { Value = "S", Text = "SOLICITADO" },
                new { Value = "C", Text = "CANCELADO" },
                new { Value = "A", Text = "ATENDIDO" }
            }, "Value", "Text");
        }




        private SelectList ObterAtendimentos()
        {
            IEnumerable<AtendimentoDTO> listaAtendimentos = atendimentoService.GetAll().Where(a => a.Status == "I").ToList();
            return new SelectList(listaAtendimentos, "Id", "Id", null);
        }


        private SelectList ObterGarcons()
        {
            IEnumerable<FuncionarioDTO> listaGarcons = funcionarioService.GetAll();
            return new SelectList(listaGarcons, "Id", "Nome", null);
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

            PedidoViewModel pedidoViewModel= new PedidoViewModel();

            pedidoViewModel.ListaAtendimentos = ObterAtendimentos();
            pedidoViewModel.ListaGarcons = ObterGarcons();
            CarregarStatus();

            return View(pedidoViewModel);
        }

        // POST: PedidoController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                var atendimento = atendimentoService.Get(pedidoViewModel.IdAtendimento);
                if (atendimento != null)
                {
                    pedidoViewModel.DaaHoraAtendimento = atendimento.DataHoraInicio ;
                }
                pedidoViewModel.DataHoraSolicitacao = DateTime.Now;
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
            IEnumerable<FuncionarioDTO> listaGarcons = funcionarioService.GetAll();
            IEnumerable<AtendimentoDTO> listaAtendimentos = atendimentoService.GetAll();
            pedidoViewModel.ListaGarcons = ObterGarcons();
            pedidoViewModel.ListaAtendimentos = ObterAtendimentos();
            CarregarStatus();
            return View(pedidoViewModel);
        }


        // POST: PedidoController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                var atendimento = atendimentoService.Get(pedidoViewModel.IdAtendimento);
                if (atendimento != null)
                {
                    pedidoViewModel.DaaHoraAtendimento = atendimento.DataHoraInicio;
                }
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