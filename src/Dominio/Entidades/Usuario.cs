using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades;

[Table("Usuario")]
public class Usuario : BaseEntidad
{
    [StringLength(50)]
    [Required]
    public string Contraseña { get; private set; }
    public List<Rol> Roles { get; private set; }

    public Usuario(string nombre, string contraseña)
        : base(nombre)
    {
        this.Contraseña = contraseña;
        this.Roles = new List<Rol>();
    }

    public void AsignarUn(Rol rol) => Roles.Add(rol);

    public void DesasignarRol(Rol rol) => Roles.Remove(rol);

    public void Habilitar()
    {
        //if (Habilitado == false)
        if (!Habilitado)
            Habilitado = true;
        else
            throw new Exception($"El usuario ya se encuentra habilitado");
    }

    public void Deshabilitar()
    {
        if (Habilitado)
            Habilitado = false;
        else
            throw new Exception($"El usuario no se encuentra habilitado");
    }

    public void Actualizar(string nombre, string contraseña)
    {
        this.Nombre = nombre;
        this.Contraseña = contraseña;
    }
}
