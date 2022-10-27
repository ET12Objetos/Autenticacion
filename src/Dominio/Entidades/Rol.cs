using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades;

[Table("Rol")]
public class Rol : BaseEntidad
{
    public List<Usuario> Usuarios { get; private set; }

    public Rol(string nombre)
        : base(nombre)
    {
        this.Usuarios = new List<Usuario>();
    }

    public void Habilitar()
    {
        //if (Habilitado == false)
        if (!Habilitado)
            Habilitado = true;
        else
            throw new Exception($"El rol ya se encuentra habilitado");
    }

    public void Deshabilitar()
    {
        if (Habilitado)
            Habilitado = false;
        else
            throw new Exception($"El rol no se encuentra habilitado");
    }

    public void Actualizar(Rol rol)
    {
        this.Nombre = rol.Nombre;
    }
}
