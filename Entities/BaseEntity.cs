using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixIt.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Activa { get; set; } = true;
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}