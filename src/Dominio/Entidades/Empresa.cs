using Dominio.Contratos;

namespace Dominio.Entidades;

public class Empresa : IEmpresa
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


    public void CrearUsuario(string nombre, string contraseña) =>
        this.Usuarios.Add(new Usuario(nombre, contraseña));

    public void CrearEmpleado(string nombre, string apellido, string email) =>
        this.Empleados.Add(new Empleado(nombre, apellido, email));

    public void CrearRol(string nombreRol) =>
            this.Roles.Add(new Rol(nombreRol));

    public void EliminarUsuario(Guid id)
    {
        var usuario = this.Usuarios.SingleOrDefault(x => x.Id == id);

        if (usuario is null)
            throw new Exception($"No existe usuario con Id {id}");

        this.Usuarios.Remove(usuario);
    }

    public void EliminarEmpleado(Guid id)
    {
        var empleado = this.Empleados.SingleOrDefault(x => x.Id == id);

        if (empleado is null)
            throw new Exception($"No existe empleado con Id {id}");

        this.Empleados.Remove(empleado);
    }

    public void EliminarRol(Guid id)
    {
        var rol = this.Roles.SingleOrDefault(x => x.Id == id);

        if (rol is null)
            throw new Exception($"No existe rol con Id {id}");

        this.Roles.Remove(rol);
    }


    public bool Login(string usuario, string contraseña, string rol)
    {
        return true;
    }

    public void ActualizarRol(Guid id, Rol rol)
    {
        var rolActual = this.Roles.SingleOrDefault(x => x.Id == id);

        if (rolActual is null)
            throw new Exception($"No existe rol con Id {id}");

        //rol.Nombre = nombre; no se puede realizar pues "nombre" es privado
        rolActual.SetNombre(rol.Nombre);
    }

    public void ActualizarEmpleado(Guid id, Empleado empleado)
    {
        var empleadoActual = this.Empleados.SingleOrDefault(x => x.Id == id);

        if (empleadoActual is null)
            throw new Exception($"No existe rol con Id {id}");

        //rol.Nombre = nombre; no se puede realizar pues "nombre" es privado
        //empleadoActual.SetNombre(empleado.Nombre);
    }

    public void ActualizarUsuario(Guid id, Usuario usuario)
    {
        var usuarioActual = this.Usuarios.SingleOrDefault(x => x.Id == id);

        if (usuarioActual is null)
            throw new Exception($"No existe rol con Id {id}");

        //rol.Nombre = nombre; no se puede realizar pues "nombre" es privado
        //usuarioActual.SetNombre(usuario.Nombre);
    }
}
