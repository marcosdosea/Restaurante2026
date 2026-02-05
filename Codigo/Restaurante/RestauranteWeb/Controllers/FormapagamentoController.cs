using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class FormapagamentoController : Controller
    {
		private readonly IFormapagamentoService _formaPagamentoService;
		private readonly IMapper _mapper;

		public FormapagamentoController(IFormapagamentoService formaPagamentoService, IMapper mapper)
		{
			_formaPagamentoService = formaPagamentoService;
			_mapper = mapper;
		}

		// GET: FormapagamentoController
		public ActionResult Index()
		{
			var formaPagamento = _formaPagamentoService.GetAll();
			var formaPagamentoViewModel = _mapper.Map<List<FormapagamentoViewModel>>(formaPagamento);
			return View(formaPagamentoViewModel);
		}


		// GET: FormapagamentoController/Details/5
		public ActionResult Details(uint id)
		{
			var formaPagamento = _formaPagamentoService.Get(id);
			var formaPagamentoViewModel = _mapper.Map<FormapagamentoViewModel>(formaPagamento);
			return View(formaPagamentoViewModel);
		}

		// GET: FormapagamentoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FormapagamentoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FormapagamentoViewModel formaPagamentoViewModel)
		{
			if (ModelState.IsValid)
			{
				var formaPagamento = _mapper.Map<Core.Formapagamento>(formaPagamentoViewModel);
				_formaPagamentoService.Create(formaPagamento);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: FormapagamentoController/Edit/5
		public ActionResult Edit(uint id)
		{
			var formaPagamento = _formaPagamentoService.Get(id);
			var formaPagamentoViewModel = _mapper.Map<FormapagamentoViewModel>(formaPagamento);
			return View(formaPagamentoViewModel);
		}

		// POST: FormapagamentoController/Edit/5

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(FormapagamentoViewModel formapagamentoViewModel)
		{
			if (ModelState.IsValid)
			{
				var formaPagamento = _mapper.Map<Core.Formapagamento>(formapagamentoViewModel);
				_formaPagamentoService.Edit(formaPagamento);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: FormapagamentoController/Delete/5
		public ActionResult Delete(uint id)
		{
			var formaPagamento = _formaPagamentoService.Get(id);
			var formaPagamentoViewModel = _mapper.Map<FormapagamentoViewModel>(formaPagamento);
			return View(formaPagamentoViewModel);
		}

		// POST: FormapagamentoController/Delete/5


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(uint id, FormapagamentoViewModel formaPagamentoViewModel)
		{
			var formaPagamento= _mapper.Map<Core.Formapagamento>(formaPagamentoViewModel);
			_formaPagamentoService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

	}
}
