using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades;

[Table("Empleado")]
public class Empleado
{
    [Key]
    [Required]
    public Guid Id { get; private set; }

    [StringLength(50)]
    [Required]
    public string Nombre { get; private set; }

    [StringLength(50)]
    [Required]
    public string Apellido { get; private set; }

    [StringLength(30)]
    [Required]
    public string Email { get; private set; }
    public Usuario Usuario { get; private set; } = null!;

    public Empleado(string nombre, string apellido, string email)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
    }
}
