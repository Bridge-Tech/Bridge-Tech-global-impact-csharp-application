using System;

namespace global_impact_idoei.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        public DateTime DtRecebimento { get; set; }
        public int IdOng { get; set; } //FK
        public int IdEmpresa { get; set; } //FK
        public int IdAlimento { get; set; } //FK
    }
}
