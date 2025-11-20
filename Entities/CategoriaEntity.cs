using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixIt.Entities
{
    public class CategoriaEntity
    {
        public string Nombre { get; set; }
        public string Urgencia { get; set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; } = true;
    }
}