using global_impact_idoei.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace global_impact_idoei.Repositories
{
    public interface IOngRepository
    {
        void Cadastrar(Ong ong);
        IList<Ong> Listar();
        Task<List<Ong>> BuscarPorId(int id);
        void Salvar();
        void Remover(int id);
        void Editar(Ong ong);
    }
}
