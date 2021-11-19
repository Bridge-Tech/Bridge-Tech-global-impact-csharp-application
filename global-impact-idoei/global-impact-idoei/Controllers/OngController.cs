using global_impact_idoei.Models;
using global_impact_idoei.Persistencia;
using global_impact_idoei.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace global_impact_idoei.Controllers
{
    public class OngController : Controller
    {
        private iDoeiContext _context;
        private IOngRepository _ongRepository;

        public OngController(iDoeiContext context, IOngRepository ongRepository)
        {
            _context = context;
            _ongRepository = ongRepository;
        }

        [HttpPost]
        public IActionResult Cadastrar(Ong ong)
        {
            if (ModelState.IsValid)
            {
                _ongRepository.Cadastrar(ong);
                _ongRepository.Salvar();
                TempData["msg"] = "Ong registrada";
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Editar(Ong ong)
        {
            _ongRepository.Editar(ong);
            _ongRepository.Salvar();
            TempData["msg"] = "Ong atualizada!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var ong = _context.Ongs.Find(id);
            return View(ong);
        }

        public IActionResult Index()
        {
            var lista = _context.Ongs.DefaultIfEmpty().ToList();
            return View(lista);
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _ongRepository.Remover(id);
            _ongRepository.Salvar();
            TempData["msg"] = "Ong removida!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
