namespace Dominio.Entidades;

public class Rol : BaseEntidad
{
    public List<Usuario> Usuarios { get; private set; }

    public Rol(string nombre)
        : base(nombre)
    {
        this.Usuarios = new List<Usuario>();
    }

    public void SetNombre(string nombre) => this.Nombre = nombre;
}
