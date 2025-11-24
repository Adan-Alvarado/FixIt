using Microsoft.EntityFrameworkCore;
using FixIt.Entities;
using Mapster;
using FixIt.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext y la conexión
builder.Services.AddDbContext<FixItDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Mapster Configuration
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(ReporteMapping).Assembly);
builder.Services.AddMapster();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();