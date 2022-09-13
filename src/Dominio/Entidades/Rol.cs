namespace Dominio.Entidades;

public class Rol
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public bool Habilitado { get; set; } = false;
    public List<Usuario> Usuarios { get; set; }

    public Rol(string nombre)
    {
        this.Nombre = nombre;
        this.Id = Guid.NewGuid();
        this.Usuarios = new List<Usuario>();
    }
}
