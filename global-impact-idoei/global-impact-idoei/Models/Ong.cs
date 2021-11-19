using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace global_impact_idoei.Models
{
    [Table("Tb_Ong")]
    public class Ong
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string AreaAtuacao { get; set; }

        //public int IdDoacao { get; set; } //FK
    }
}
