using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PROGRAM.Models
{
    [Table("Procedimiento")]
    public class Procedimiento
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [NotMapped]
        public List<string>? DescripcionCheckBoxList { get; set; }
    }
}
