
namespace FixIt.Entities
{
    

    public class ReporteEntity
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Guid CategoriaId { get; set; } // 
        public Guid UsuarioId { get; set; } // quien reporta
        public DateTime FechaCreacion { get; set; }
        public String EstadoReporte { get; set; } //pendiente, en proceso, resuelto

    }
}