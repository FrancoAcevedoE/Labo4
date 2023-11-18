using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGRAM.Models
{
    [Table("Equipo")]
    public class Equipo
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Contador")]
        public int? ContadorRefId { get; set; }

        [ForeignKey("ContadorRefId")]
        public virtual Contador? Contador { get; set; }

        [Display(Name = "Procedimiento")]
        public int ProcedimientoRefId { get; set; }

        [ForeignKey("ProcedimientoRefId")]
        public virtual Procedimiento? Procedimiento { get; set; }


    }
}
