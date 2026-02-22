using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    [Authorize]
    public class AtendimentoController : Controller
    {
        private readonly IMesaService mesaService;
        private readonly IAtendimentoService atendimentoService;
        private readonly IMapper mapper;
        public AtendimentoController(IMesaService mesaService, IAtendimentoService atendimentoService, IMapper mapper)
        {
            this.mesaService = mesaService;
            this.atendimentoService = atendimentoService;
            this.mapper = mapper;

        }

        private void CarregarStatus()
        {
            ViewBag.StatusList = new SelectList(new[]
            {
                new { Value = "I", Text = "INICIADO" },
                new { Value = "C", Text = "CANCELADO" },
                new { Value = "F", Text = "FINALIZADO" }
            }, "Value", "Text");
        }
        private SelectList ObterMesasDisponiveis()
        {
            IEnumerable<Mesa> listaMesas = mesaService.GetAll();
            atendimentoService.GetAll().Where(a => a.Status == "I").ToList().ForEach(a =>
            {
                var mesaOcupada = listaMesas.FirstOrDefault(m => m.Id == a.IdMesa);
                if (mesaOcupada != null)
                {
                    listaMesas = listaMesas.Where(m => m.Id != mesaOcupada.Id);
                }
            });

            return new SelectList(listaMesas, "Id", "Identificacao", null);
        }


        // GET: AtendimentoController
        public ActionResult Index()
        {
            var listaAtendimentos = atendimentoService.GetAll();
            return View(listaAtendimentos);
        }

        // GET: AtendimentoController/Details
        public ActionResult Details(uint id)
        {
            var atendimento = atendimentoService.Get(id);
            if(atendimento != null)
            {
                atendimento.TotalConta = atendimento.Pedidos.Sum(p => p.Pedidoitemcardapios.Sum(pic => pic.Quantidade));
                atendimento.Total = atendimento.TotalConta + atendimento.TotalServico - atendimento.TotalDesconto;
            }
            AtendimentoViewModel atendimentoViewModel = mapper.Map<AtendimentoViewModel>(atendimento);
            return View(atendimentoViewModel);
        }

        // GET: AtendimentoController/Create
        public ActionResult Create()
        {
            AtendimentoViewModel atendimentoViewModel = new();

            //mantem para escolha apenas as mesas que não estão ocupadas
            atendimentoViewModel.ListaMesas = ObterMesasDisponiveis();

            //viewbag para manter a lista de status mais clara 
            CarregarStatus();

            return View(atendimentoViewModel);
        }

        // POST: AtendimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AtendimentoViewModel atendimentoViewModel)
        {
            atendimentoViewModel.DataHoraInicio = DateTime.Now;
            if (ModelState.IsValid)
            {
                var atendimento = mapper.Map<Atendimento>(atendimentoViewModel);
                atendimentoService.Create(atendimento);           
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: AtendimentoController/Edit
        public ActionResult Edit(uint id)
        {
            var atendimento = atendimentoService.Get(id);
            var atendimentoViewModel = mapper.Map<AtendimentoViewModel>(atendimento);
            IEnumerable<Mesa> listaMesas = mesaService.GetAll();
            //mantem para escolha apenas as mesas que não estão ocupadas
            atendimentoViewModel.ListaMesas = ObterMesasDisponiveis();
            CarregarStatus();

            return View(atendimentoViewModel);
        }
        
        // POST: AtendimentoController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AtendimentoViewModel atendimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var atendimento = mapper.Map<Atendimento>(atendimentoViewModel);
                atendimentoService.Edit(atendimento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AtendimentoController/Delete
        public ActionResult Delete(uint id)
        {
            var atendimento = atendimentoService.Get(id);
            AtendimentoViewModel atendimentoViewModel = mapper.Map<AtendimentoViewModel>(atendimento);
            return View(atendimentoViewModel);
        }

        // POST: AtendimentoController/Delete
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AtendimentoViewModel atendimentoViewModel)
        {
            atendimentoService.Delete(atendimentoViewModel.Id);
            return RedirectToAction(nameof(Index));
        }


    }
}
