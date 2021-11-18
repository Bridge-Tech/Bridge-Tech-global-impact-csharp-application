using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace global_impact_idoei.Models
{
    [Table("Tb_Empresa")]
    public class Empresa
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cnpj { get; set; }

        [Required]
        public string Endereco { get; set; }

        public string TipoAlimento { get; set; }
        public int IdDoacao { get; set; } //FK
        public int IdAlimento { get; set; } //FK
    }
}
