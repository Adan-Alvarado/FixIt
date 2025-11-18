using Microsoft.EntityFrameworkCore;
using fixIt.Api.Entities;

public class FixItDbContext : DbContext
{
    public FixItDbContext(DbContextOptions<FixItDbContext> options)
        : base(options)
    {
    }

    public DbSet<Reporte> Reportes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
