namespace FixIt.Dtos.Reportes
{
    public class ReporteItemDto
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Ciudad { get; set; }
        public string BarrioColonia { get; set; }
        public string Estado { get; set; }

    }
}