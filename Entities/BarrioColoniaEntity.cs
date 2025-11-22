using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FixIt.Entities
{
    public class BarrioColoniaEntity : BaseEntity
    {
        [Column("nombre")]
        public string Nombre { get; set; }
        public string Referencia { get; set; }
    }
}