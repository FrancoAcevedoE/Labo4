using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGRAM.Models
{
    [Table("OrdenDeTrabajo")]
    public class OrdenDeTrabajo
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Display(Name = "Tipo de Orden de Trabajo")]
        public string? TipoOT { get; set; }

        [Display(Name = "Responsable")]
        public int? ManoDeObraRefId { get; set; }

        [ForeignKey("ManoDeObraRefId")]
        public virtual ManoDeObra? ManoDeObra { get; set; }

        [Display(Name = "Equipo")]
        public int? EquipoRefId { get; set; }

        [ForeignKey("EquipoRefId")]
        public virtual Equipo? Equipo { get; set; }

        [Display(Name = "Procedimiento")]
        public int? ProcedimientoRefId { get; set; }

        [ForeignKey("ProcedimientoRefId")]
        public virtual Procedimiento? Procedimiento { get; set; }

        [Display(Name = "Materiales")]
        public int? MaterialesRefId { get; set; }

        [ForeignKey("MaterialesRefId")]
        public virtual Material? Material { get; set; }
 

    }
}
