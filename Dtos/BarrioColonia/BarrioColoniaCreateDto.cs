using System.ComponentModel.DataAnnotations;

namespace FixIt.Dtos.BarrioColonia
{
    public class BarrioColoniaCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Referencia")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string Referencia { get; set; }   
    }
}