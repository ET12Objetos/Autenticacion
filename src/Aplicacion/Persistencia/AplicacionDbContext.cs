using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Persistencia;
public class AplicacionDbContext : DbContext
{
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> opciones)
        : base(opciones)
    {

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
}