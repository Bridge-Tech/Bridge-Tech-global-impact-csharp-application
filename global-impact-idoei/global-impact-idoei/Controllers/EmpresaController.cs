using global_impact_idoei.Repositories;
using Microsoft.AspNetCore.Mvc;
using global_impact_idoei.ViewModel;
using global_impact_idoei.Models;

namespace global_impact_idoei.Controllers
{
    public class EmpresaController : Controller
    {
        private IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public IActionResult Index()
        {
            return View(CarregarViewModel());
        }

        private EmpresaViewModel CarregarViewModel()
        {
            return new EmpresaViewModel()
            {
                Lista = _empresaRepository.Listar()
            };
        }

        [HttpPost]
        public IActionResult Cadastrar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _empresaRepository.Cadastrar(empresa);
                _empresaRepository.Salvar();
                TempData["msg"] = "Empresa registrada";
                return RedirectToAction("Index");
            }
            return View("Index", CarregarViewModel());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
