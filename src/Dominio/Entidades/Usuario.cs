namespace Dominio.Entidades;

public class Usuario : BaseEntidad
{
    public string Contraseña { get; private set; }
    public List<Rol> Roles { get; private set; }

    public Usuario(string nombre, string contraseña)
        : base(nombre)
    {
        this.Contraseña = contraseña;
        this.Roles = new List<Rol>();
    }
}
