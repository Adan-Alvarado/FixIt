using Microsoft.EntityFrameworkCore;
using FixIt.Entities;
using Mapster;
using FixIt.Mappings;
using Scalar.AspNetCore;
using FixIt.Services.Reportes;
using FixIt.Api.Services.Categoria;
using FixIt.Api.Services.Ciudades;
using fixIt.Api.Services.Ciudades;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext y la conexión
builder.Services.AddDbContext<FixItDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Mapster Configuration
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(ReporteMapping).Assembly);
builder.Services.AddMapster();

//Add Services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Custom Services
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICiudadesService, CiudadesService>();


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();