namespace Dominio.Entidades;

public class Rol
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; }
    public bool Habilitado { get; private set; } = false;
    public List<Usuario> Usuarios { get; private set; }

    public Rol(string nombre)
    {
        this.Nombre = nombre;
        this.Id = Guid.NewGuid();
        this.Usuarios = new List<Usuario>();
    }
}
