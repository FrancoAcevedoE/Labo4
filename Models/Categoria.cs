using System.ComponentModel.DataAnnotations;

namespace PROGRAM.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name ="Categoría")]
        public string? Categoría { get; set; }

        [Display(Name = "Valor")]
        public int? Valor { get; set; }
    }
}
