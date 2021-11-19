using global_impact_idoei.Repositories;
using Microsoft.AspNetCore.Mvc;
using global_impact_idoei.ViewModel;
using global_impact_idoei.Models;
using global_impact_idoei.Persistencia;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace global_impact_idoei.Controllers
{
    public class EmpresaController : Controller
    {
        private iDoeiContext _context;
        private IEmpresaRepository _empresaRepository;
        public EmpresaController(iDoeiContext context, 
            IEmpresaRepository empresaRepository)
        {
            _context = context;
            _empresaRepository = empresaRepository;
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
            return View("Index");
        }

        [HttpPost]
        public IActionResult Editar(Empresa empresa)
        {
            _empresaRepository.Editar(empresa);
            _empresaRepository.Salvar();
            TempData["msg"] = "Empresa atualizada!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var empresa = _context.Empresas.Find(id);
            return View(empresa);
        }

        public IActionResult Index()
        {
            var lista = _context.Empresas.DefaultIfEmpty().ToList();
            return View(lista);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _empresaRepository.Remover(id);
            _empresaRepository.Salvar();
            TempData["msg"] = "Empresa removida!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
