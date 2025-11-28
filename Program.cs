using Microsoft.EntityFrameworkCore;
using FixIt.Entities;
using Mapster;
using FixIt.Mappings;
using Scalar.AspNetCore;
using FixIt.Services.Reportes;
using FixIt.Services.BarrioColonia;

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
builder.Services.AddScoped<IBarrioColoniaService,BarrioColoniaService>();
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