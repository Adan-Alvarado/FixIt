using System.ComponentModel.DataAnnotations;

namespace FixIt.Dtos
{
    public class ReporteCreateDto
    {
        [Display(Name = "Reporte Id")]
        public Guid Id { get; set; }

        [Display(Name = "Título del Reporte")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [StringLength(250, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción del Reporte")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(2000, ErrorMessage = "La {0} no puede tener más de {1} caracteres.")]
        public string Descripcion { get; set; }
        
        [Display(Name = "CategoriaId")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public Guid CategoriaId { get; set; }

        [Display(Name = "UsuarioId")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public Guid UsuarioId { get; set; }
        
        [Display(Name = "Fecha de Creacion")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Estado del Reporte")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Range(1, 3, ErrorMessage = "El {0} debe ser un valor entre {1} y {2}.")]
        public string EstadoReporte { get; set; } //pendiente, en proceso, resuelto
        
        [Display(Name = "URL Multimedia")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string URLMultimedia { get; set; }

    }
}