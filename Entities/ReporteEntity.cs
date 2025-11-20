
namespace FixIt.Entities
{
    public class ReporteEntity
    {
        public string Titulo { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid ZonaId { get; set; }
        public string Descripcion { get; set; }
        public string Calle { get; set; }
        public string Referencia { get; set; }
        public bool EstadoReporte { get; set; } //pendiente, en proceso, resuelto
        public string URLMultimedia { get; set; }
    }
}