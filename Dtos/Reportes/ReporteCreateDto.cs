using System.ComponentModel.DataAnnotations;

namespace FixIt.Dtos.Reportes
{
    public class ReporteCreateDto
    {
        [Display(Name = "Categoría")]
        [Range(1,10, ErrorMessage =  "La {0} de la categoría debe estar entre 1 y 10.")]
        public Guid CategoriaId { get; set; }

        
        public Guid BarrioColoniaId { get; set; }
        public Guid CiudadId { get; set; }
        public string Descripcion { get; set; }
        public string Calle { get; set; }
        public string Referencia { get; set; }
        public string URLMultimedia { get; set; }
    }
}