namespace Dominio.Entidades;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; }
    public string Contraseña { get; private set; }
    public bool Habilitado { get; set; } = false;
    public List<Rol> Roles { get; private set; }

    public Usuario(string nombre, string contraseña)
    {
        this.Nombre = nombre;
        this.Contraseña = contraseña;
        this.Id = Guid.NewGuid();
        this.Roles = new List<Rol>();
    }
}
