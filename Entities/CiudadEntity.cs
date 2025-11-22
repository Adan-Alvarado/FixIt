using System.ComponentModel.DataAnnotations.Schema;

namespace FixIt.Entities
{
    public class CiudadEntity : BaseEntity
    {
        [Column("nombre")]
        public string Nombre { get; set; }

        public virtual IEnumerable<ReporteEntity> Reportes { get; set; }
    }
}