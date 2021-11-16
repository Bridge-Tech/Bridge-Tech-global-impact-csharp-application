using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace global_impact_idoei.Models
{
    [Table("Tb_Resultado")]
    public class Resultado
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public DateTime DtRealizacao { get; set; }

        [Required]
        public int IdOng { get; set; } //FK
    }
}
