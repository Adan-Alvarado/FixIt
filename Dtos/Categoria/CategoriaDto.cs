namespace fixIt.Api.Dtos
{
    public class CategoriaDto
    {
          public Guid Id { get; set; }
          public string Nombre { get; set; }
          public string Urgencia { get; set; }
          public string Descripcion { get; set; }
    }
}