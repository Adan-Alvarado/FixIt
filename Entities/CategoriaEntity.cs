using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixIt.Entities
{
    public class CategoriaEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Descripcion { get; set; }
        public bool Activa { get; set; } = true;
    }
}