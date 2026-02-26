using AutoMapper;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestauranteWeb.Models;
using Service;

namespace RestauranteWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IFuncaoFuncionarioService _funcaoService;
        private readonly IRestauranteService _restauranteService; // NOVO SERVIÇO
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioService funcionarioService,
                                     IFuncaoFuncionarioService funcaoService,
                                     IRestauranteService restauranteService,
                                     IMapper mapper)
        {
            _funcionarioService = funcionarioService;
            _funcaoService = funcaoService;
            _restauranteService = restauranteService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var listaDTO = _funcionarioService.GetAll();
            var listaViewModel = _mapper.Map<List<FuncionarioViewModel>>(listaDTO);
            return View(listaViewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new FuncionarioViewModel();
            viewModel.ListaFuncoes = new SelectList(_funcaoService.GetAll(), "Id", "Nome");
            viewModel.ListaRestaurantes = new SelectList(_restauranteService.GetAll(), "Id", "Nome");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<FuncionarioDTO>(viewModel);
                _funcionarioService.Create(dto);
                return RedirectToAction(nameof(Index));
            }
            viewModel.ListaFuncoes = new SelectList(_funcaoService.GetAll(), "Id", "Nome", viewModel.IdFuncaoFuncionario);
            viewModel.ListaRestaurantes = new SelectList(_restauranteService.GetAll(), "Id", "Nome", viewModel.IdRestaurante);
            return View(viewModel);
        }

        public ActionResult Details(uint id)
        {
            var funcionario = _funcionarioService.Get(id);
            var viewModel = _mapper.Map<FuncionarioViewModel>(funcionario);
            return View(viewModel);
        }

        public ActionResult Edit(uint id)
        {
            var dto = _funcionarioService.Get(id);
            if (dto == null) return NotFound();

            var viewModel = _mapper.Map<FuncionarioViewModel>(dto);
            viewModel.ListaFuncoes = new SelectList(_funcaoService.GetAll(), "Id", "Nome", dto.IdFuncaoFuncionario);
            viewModel.ListaRestaurantes = new SelectList(_restauranteService.GetAll(), "Id", "Nome", dto.IdRestaurante);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, FuncionarioViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<FuncionarioDTO>(viewModel);
                _funcionarioService.Edit(dto);
                return RedirectToAction(nameof(Index));
            }
            viewModel.ListaFuncoes = new SelectList(_funcaoService.GetAll(), "Id", "Nome", viewModel.IdFuncaoFuncionario);
            viewModel.ListaRestaurantes = new SelectList(_restauranteService.GetAll(), "Id", "Nome", viewModel.IdRestaurante);
            return View(viewModel);
        }

        public ActionResult Delete(uint id)
        {
            var dto = _funcionarioService.Get(id);
            if (dto == null) return NotFound();
            var viewModel = _mapper.Map<FuncionarioViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, FuncionarioViewModel viewModel)
        {
            _funcionarioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}