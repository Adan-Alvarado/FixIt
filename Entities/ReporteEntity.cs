
namespace FixIt.Entities
{
    public class ReporteEntity : BaseEntity
    {
        public Guid CategoriaId { get; set; }
        public Guid BarrioColoniaId { get; set; }
        public Guid CiudadId { get; set; }
        public string Descripcion { get; set; }
        public string Calle { get; set; }
        public string Referencia { get; set; }
        public bool EstadoReporte { get; set; } //pendiente, en proceso, resuelto
        public string URLMultimedia { get; set; }
    }
}