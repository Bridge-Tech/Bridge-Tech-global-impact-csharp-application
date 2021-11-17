using global_impact_idoei.Models;
using System.Collections.Generic;

namespace global_impact_idoei.ViewModel
{
    public class EmpresaViewModel
    {
        public Empresa Empresa { get; set; }
        public IList<Empresa> Lista { get; set; }
    }
}
