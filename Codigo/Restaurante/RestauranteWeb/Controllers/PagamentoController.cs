using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    [Authorize] // Requisito do Professor: Autenticação obrigatória
    public class PagamentoController : Controller
    {
        private readonly IPagamentoService _pagamentoService;
        private readonly IAtendimentoService _atendimentoService;
        private readonly IFormapagamentoService _formaPagamentoService;
        private readonly IMapper _mapper;

        public PagamentoController(IPagamentoService pagamentoService, IAtendimentoService atendimentoService, IFormapagamentoService formaPagamentoService, IMapper mapper)
        {
            _pagamentoService = pagamentoService;
            _atendimentoService = atendimentoService;
            _formaPagamentoService = formaPagamentoService;
            _mapper = mapper;
        }

        // GET: Pagamento/Create?idAtendimento=5
        public ActionResult Create(uint idAtendimento)
        {
            var atendimento = _atendimentoService.Get(idAtendimento);
            if (atendimento == null || atendimento.Status == "F")
            {

                return RedirectToAction("Index", "Atendimento");
            }

            var totalPago = _pagamentoService.GetTotalPago(idAtendimento);
            var faltante = atendimento.Total - totalPago;

            var viewModel = new PagamentoViewModel
            {
                IdAtendimento = idAtendimento,
                TotalAtendimento = atendimento.Total,
                ValorFaltante = faltante,
                Valor = faltante 
            };

            ViewBag.IdFormaPagamento = new SelectList(_formaPagamentoService.GetAll(), "Id", "Nome"); 
            return View(viewModel);
        }

        // POST: Pagamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagamentoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var pagamento = _mapper.Map<Pagamento>(viewModel);
                _pagamentoService.Create(pagamento);

                return RedirectToAction("Details", "Atendimento", new { id = viewModel.IdAtendimento });
            }

            ViewBag.IdFormaPagamento = new SelectList(_formaPagamentoService.GetAll(), "Id", "Nome", viewModel.IdFormaPagamento);
            return View(viewModel);
        }
    }
}