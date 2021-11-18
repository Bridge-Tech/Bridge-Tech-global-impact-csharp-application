using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace global_impact_idoei.Models
{
    [Table("Tb_Doacao")]
    public class Doacao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public DateTime DtRecebimento { get; set; }

        [Required]
        public int IdOng { get; set; } //FK

        [Required]
        public int IdEmpresa { get; set; } //FK

        [Required]
        public int IdAlimento { get; set; } //FK

        public bool Disponivel { get; set; }
    }
}
