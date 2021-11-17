using global_impact_idoei.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace global_impact_idoei.Repositories
{
    public interface IEmpresaRepository
    {
        void Cadastrar(Empresa empresa);
        IList<Empresa> Listar();
        Task<List<Empresa>> BuscarPorId(int id);
        void Salvar();
    }
}
