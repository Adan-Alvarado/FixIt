using Microsoft.EntityFrameworkCore;
using FixIt.Entities;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext y la conexión
builder.Services.AddDbContext<FixItDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();