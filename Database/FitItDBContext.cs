
namespace fixIt.Api.Database
{
    public class FitItDBContext
    {
        [Column("id")]
        public Guid Id { get; set; }

        //Auditoia
        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("categoria_id")]
        public string CategoriaId { get; set; }   

        [Column("usuario_id")]
        public string UsuarioId { get; set; } 
        
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }
       
        [Column("fecha_creacion")]
        public string EstadoReporte { get; set; }
        
        [Column("url_multimedia")]
        public string URLMultimedia { get; set; }
    }
}