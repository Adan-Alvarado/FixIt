
using System.ComponentModel.DataAnnotations.Schema;

namespace FixIt.Entities
{
    public class ReporteEntity : BaseEntity
    {
        public Guid CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual CategoriaEntity Categoria { get; set; }

        public Guid BarrioColoniaId { get; set; }
        [ForeignKey("BarrioColoniaId")]
        public virtual BarrioColoniaEntity BarrioColonia { get; set; }

        public Guid CiudadId { get; set; }
        [ForeignKey("CiudadId")]
        public virtual CiudadEntity Ciudad { get; set; }

        public string Descripcion { get; set; }
        public string Calle { get; set; }
        public string Referencia { get; set; }
        public bool EstadoReporte { get; set; } //pendiente, en proceso, resuelto
        public string URLMultimedia { get; set; }
    }
}