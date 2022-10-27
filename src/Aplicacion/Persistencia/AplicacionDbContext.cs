using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Persistencia;

public class AplicacionDbContext : DbContext
{
    //Constructor con opciones se va usar para crear la base de datos desde codigo C#
    //SQL -> CREATE DATABASE proyecto_db;
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> opciones)
        : base(opciones)
    {

    }

    //Cada lista representa se persisten en una tabla en una base de datos relacional (MySql)
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
}