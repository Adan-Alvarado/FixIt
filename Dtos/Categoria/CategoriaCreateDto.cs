using System.ComponentModel.DataAnnotations;

namespace fixIt.Api.Dtos.Categoria
{
    public class CategoriaCreateDto
    {
        [Display(Name = "Nombre de la categoria")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar los {1} caracteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Nivel de urgencia")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(50, ErrorMessage = "La {0} no puede superar los {1} caracteres.")]
        public string Urgencia { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(500, ErrorMessage = "La {0} no puede superar los {1} caracteres.")]
        public string Descripcion { get; set; }
    }
}
