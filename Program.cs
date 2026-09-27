using ApiClientes.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Controllers
builder.Services.AddControllers();

// Agregar OpenAPI
builder.Services.AddOpenApi();

// Configurar Entity Framework Core con MySQL
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Conexiones>(options =>
    options.UseMySQL(connectionString!));

var app = builder.Build();

// Configuración para Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();