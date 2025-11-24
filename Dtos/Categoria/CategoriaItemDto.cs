namespace fixIt.Api.Dtos.Categoria
{
    public class CategoriaItemDto
    {
        public Guid Id { get; set; }        
        public string Nombre { get; set; }
        public string Urgencia { get; set; }
        public string Descripcion { get; set; }
    }
}
