using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace global_impact_idoei.Models
{
    [Table("Tb_Alimento")]
    public class Alimento
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string TipoAlimento { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
