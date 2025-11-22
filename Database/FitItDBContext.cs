using Microsoft.EntityFrameworkCore;
using FixIt.Entities;

public class FixItDbContext : DbContext
{
    public FixItDbContext(DbContextOptions<FixItDbContext> options)
        : base(options)
    {
    }

    public DbSet<ReporteEntity> Reportes { get; set; }
    public DbSet<CiudadEntity> Ciudades { get; set; }
    public DbSet<BarrioColoniaEntity> BarriosColonias { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }

}
