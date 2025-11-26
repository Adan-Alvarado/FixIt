using System.ComponentModel.DataAnnotations;
namespace fixIt.Api.Dtos
{
    public class CiudadesCreateDto
    {
        [Display(Name = "Nombre de la ciudad")]
        [StringLength(60, ErrorMessage = "El {0} no puede superar los {1} caracteres.")]
        public string Nombre { get; set; }

    }
}