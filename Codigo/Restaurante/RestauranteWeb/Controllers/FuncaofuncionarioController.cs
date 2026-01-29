using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RestauranteWeb.Controllers
{
    public class FuncaofuncionarioController : Controller
    {
        private readonly IFuncaoFuncionarioService funcaoFuncionarioService;
        private readonly IMapper mapper;

        public FuncaofuncionarioController(IFuncaoFuncionarioService funcaoFuncionarioService, IMapper mapper)
        {
            this.funcaoFuncionarioService = funcaoFuncionarioService;
            this.mapper = mapper;
        }

        // GET: FuncaofuncionarioController
        public ActionResult Index()
        {
            var listaFuncoesFuncionarios = funcaoFuncionarioService.GetAll();
            var listaFuncoesFuncionariosViewModel = mapper.Map<List<FuncaofuncionarioViewModel>>(listaFuncoesFuncionarios);
            return View(listaFuncoesFuncionariosViewModel);
        }

        // GET: FuncaofuncionarioController/Details/5
        public ActionResult Details(int id)
        {
            var funcaoFuncionario = funcaoFuncionarioService.Get((uint)id);
            FuncaofuncionarioViewModel funcaoFuncionarioViewModel = mapper.Map<FuncaofuncionarioViewModel>(funcaoFuncionario);
            return View(funcaoFuncionarioViewModel);
        }

        // GET: FuncaofuncionarioController/Create
        public ActionResult Create()
        {
 
            return View();
        }

        // POST: FuncaofuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncaofuncionarioViewModel funcaofuncionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var funcaoFuncionario = mapper.Map<Funcaofuncionario>(funcaofuncionarioViewModel);
                funcaoFuncionarioService.Create(funcaoFuncionario);
                
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: FuncaofuncionarioController/Edit/5
        public ActionResult Edit(int id)
        {
            var funcaoFuncionario = funcaoFuncionarioService.Get((uint)id);
            var funcaoFuncionarioViewModel = mapper.Map<FuncaofuncionarioViewModel>(funcaoFuncionario);
            return View(funcaoFuncionarioViewModel);
        }

        // POST: FuncaofuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FuncaofuncionarioViewModel funcaofuncionarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                var funcaoFuncionario = mapper.Map<Funcaofuncionario>(funcaofuncionarioViewModel);
                funcaoFuncionarioService.Edit(funcaoFuncionario);
                
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: FuncaofuncionarioController/Delete/5
        public ActionResult Delete(int id)
        {
            var funcaoFuncionario = funcaoFuncionarioService.Get((uint)id);
            var funcaoFuncionarioViewModel = mapper.Map<FuncaofuncionarioViewModel>(funcaoFuncionario);
            return View(funcaoFuncionarioViewModel);
        }

        // POST: FuncaofuncionarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FuncaofuncionarioViewModel funcaofuncionarioViewModel)
        {
            try
            {
                
                funcaoFuncionarioService.Delete(funcaofuncionarioViewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
