using global_impact_idoei.Models;
using global_impact_idoei.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace global_impact_idoei.Repositories
{
    public class OngRepository : IOngRepository
    {
        private iDoeiContext _context;

        public OngRepository(iDoeiContext context) { _context = context; }

        public async Task<List<Ong>> BuscarPorId(int id)
        {
            var lt = await (from o in _context.Ongs
                            where o.Id.Equals(id)
                            select new Ong()
                            {
                                Id = o.Id,
                                Nome = o.Nome,
                                Endereco = o.Endereco,
                                AreaAtuacao = o.AreaAtuacao
                            }).ToListAsync();

            return lt;
        }

        public void Cadastrar(Ong ong)
        {
            _context.Ongs.Add(ong);
        }

        public void Editar(Ong ong)
        {
            _context.Ongs.Update(ong);
        }

        public IList<Ong> Listar()
        {
            return _context.Ongs.ToList();
        }

        public void Remover(int id)
        {
            var ong = _context.Ongs.Find(id);
            _context.Ongs.Remove(ong);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
