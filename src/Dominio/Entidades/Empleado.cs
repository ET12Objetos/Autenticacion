namespace Dominio.Entidades;

public class Empleado
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Email { get; private set; }
    public Usuario Usuario { get; private set; }

    public Empleado(string nombre, string apellido, string email, Usuario usuario)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Usuario = usuario;
    }
}
