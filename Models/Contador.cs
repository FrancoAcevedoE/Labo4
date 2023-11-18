using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGRAM.Models
{
    [Table("Contador")]
    public class Contador
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Display(Name = "Equipo")]
        public int? EquipoRefId { get; set; }

        [ForeignKey("EquipoRefId")]
        public virtual Equipo? Equipo { get; set; }

        [Display(Name = "Tipo")]
        public string? Tipo { get; set; }

        [Display(Name = "Valor")]
        public int Valor { get; set; }
    }
}
