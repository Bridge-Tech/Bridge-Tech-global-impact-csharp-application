using System;

namespace global_impact_idoei.Models
{
    public class Resultado
    {
        public int Id { get; set; }
        public DateTime DtRealizacao { get; set; }
        public int IdOng { get; set; } //FK
    }
}
