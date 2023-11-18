using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROGRAM.Models
{
    [Table("ManoDeObra")]
    public class ManoDeObra
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Categoria")]
        public int? CategoriaRefId { get; set; }
   
        [ForeignKey("CategoriaRefId")]
        public virtual Categoria? Categoria { get; set; }
    }
}
