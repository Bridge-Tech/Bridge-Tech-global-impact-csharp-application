using global_impact_idoei.Models;
using global_impact_idoei.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace global_impact_idoei.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private iDoeiContext _context;

        public EmpresaRepository(iDoeiContext context) { _context = context; }

        public void Cadastrar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
        }
        public void Editar(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
        }

        public async Task<List<Empresa>> BuscarPorId(int id)
        {
            var lt = await (from e in _context.Empresas
                            join d in _context.Doacoes on e.Id equals d.IdEmpresa
                            join a in _context.Alimentos on d.IdAlimento equals a.Id
                            where e.Id.Equals(id)
                            select new Empresa()
                            {
                                Id = e.Id,
                                Nome = e.Nome,
                                Cnpj = e.Cnpj,
                                Endereco = e.Endereco,
                                TipoAlimento = a.TipoAlimento,
                                IdDoacao = d.Id
                            }).ToListAsync();

            return lt;
        }

        public void Remover(int id)
        {
            var empresa = _context.Empresas.Find(id);
            _context.Empresas.Remove(empresa);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public IList<Empresa> Listar()
        {
            return _context.Empresas.ToList();
        }
    }
}
