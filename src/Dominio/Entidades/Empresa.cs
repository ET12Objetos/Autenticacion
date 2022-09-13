namespace Dominio.Entidades;

public class Empresa
{
    public List<Empleado> Empleados { get; private set; }
    public List<Usuario> Usuarios { get; private set; }
    public List<Rol> Roles { get; private set; }

    public Empresa()
    {
        this.Empleados = new List<Empleado>();
        this.Usuarios = new List<Usuario>();
        this.Roles = new List<Rol>();
    }

    public bool Login(string usuario, string contraseña, string rol)
    {
        return true;
    }
}
