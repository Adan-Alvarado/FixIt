using System.ComponentModel.DataAnnotations;

namespace FixIt.Dtos.Reportes
{
    public class ReporteCreateDto
    {
        [Display(Name = "CategoríaId")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public Guid CategoriaId { get; set; }

        [Display(Name = "Barrio/ColoniaId")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public Guid BarrioColoniaId { get; set; }

        [Display(Name = "CiudadId")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public Guid CiudadId { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(3000, ErrorMessage = "La {0} no puede tener más de {1} caracteres.")]
        public string Descripcion { get; set; }
        [Display(Name = "Calle")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string Calle { get; set; }
        [Display(Name = "Referencia")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(2000, ErrorMessage = "La {0} no puede tener más de {1} caracteres.")]
        public string Referencia { get; set; }

        [Display(Name = "URL Multimedia")]
        [Url(ErrorMessage = "La {0} debe ser una URL válida.")]
        public string URLMultimedia { get; set; }
    }
}