using fixIt.Api.Services.Categoria;
using FixIt.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext SQLite
builder.Services.AddDbContext<FixItDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Mapster
var config = TypeAdapterConfig.GlobalSettings;
// Ejemplo: config.NewConfig<CategoriaCreateDto, CategoriaEntity>().Map(dest => dest.Nombre, src => src.Nombre);

builder.Services.AddMapster();
builder.Services.AddScoped<IMapper, ServiceMapper>();

// Registrar servicios
builder.Services.AddScoped<CategoriaService>();

// ---------------------------
// Agregar controladores
builder.Services.AddControllers();

// Construir app
var app = builder.Build();

// Mapear rutas de los controladores
app.MapControllers();

app.Run();
