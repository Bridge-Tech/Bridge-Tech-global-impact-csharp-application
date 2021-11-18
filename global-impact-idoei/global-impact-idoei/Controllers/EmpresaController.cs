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
        public EmpresaController(iDoeiContext context, IEmpresaRepository empresaRepository)
        {
            _context = context;
            _empresaRepository = empresaRepository;
        }

        //[HttpGet]
        //public async IActionResult Detalhes(int id)
        //{
        //    //Pesquisar a empresa pelo Id
        //    var empresa = _empresaRepository.BuscarPorId(id);

        //    //Pesquisar docações associadas a empresa
        //    var doacoes = _context.Doacoes.Where(x => x.Disponivel).ToList();

        //    //Pesquisar docações associadas a empresa
        //    var doacoesEmpresa = from e in _context.Empresas
        //                         join d in _context.Doacoes on e.IdDoacao equals d.Id
        //                         join a in _context.Alimentos on e.IdAlimento equals a.Id
        //                         where d.Id.Equals(id)
        //                         select new Empresa()
        //                         {
        //                             Id = e.Id,
        //                             Nome = e.Nome,
        //                             Cnpj = e.Cnpj,
        //                             Endereco = e.Endereco,
        //                             TipoAlimento = a.TipoAlimento,
        //                             IdDoacao = d.Id,
        //                             IdAlimento = a.Id
        //                         };

        //    return View(empresa);
        //}

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

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _empresaRepository.Remover(id);
            _empresaRepository.Salvar();
            TempData["msg"] = "Empresa removida!";
            return RedirectToAction("Index");
        }

        //private void CarregarEmpresas()
        //{
        //    var lista = _context.Empresas.OrderBy(x => x.).ToList();

        //    ViewBag.empresas = new SelectList(lista, "EmpresaId", "Nome");
        //}

        [HttpGet]
        public IActionResult Cadastrar()
        {
            //CarregarEmpresas();
            return View();
        }
    }
}
