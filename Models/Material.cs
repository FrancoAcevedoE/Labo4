using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGRAM.Models
{
    [Table("Materiales")]
    public class Material
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }

        [Display(Name = "CodMateriales")]
        public int CodMateriales { get; set; }

        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display (Name="Valor Unitario")]
        public int? Valor { get; set; }
    }
}
