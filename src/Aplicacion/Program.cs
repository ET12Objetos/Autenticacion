using Aplicacion.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//---- :)

var cadenaConexion = builder.Configuration.GetConnectionString("pepe_db");

builder.Services.AddDbContext<AplicacionDbContext>(
    opcion => opcion.UseMySql(cadenaConexion, new MySqlServerVersion(new Version(8, 0, 30)))
);

builder.Services.AddDbContext<AplicacionDbContext>();

//crear la base de datos

var opcionesContexto = new DbContextOptionsBuilder<AplicacionDbContext>();

opcionesContexto.UseMySql(cadenaConexion, new MySqlServerVersion(new Version(8, 0, 30)));

var aplicacionContexto = new AplicacionDbContext(opcionesContexto.Options);

aplicacionContexto.Database.EnsureCreated();


//---- :/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
