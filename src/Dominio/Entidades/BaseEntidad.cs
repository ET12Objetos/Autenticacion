using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades;

public abstract class BaseEntidad
{
    [Key]
    [Required]
    public Guid Id { get; protected set; }

    [StringLength(50)]
    [Required]
    public string Nombre { get; set; }
    public bool Habilitado { get; protected set; } = false;

    public BaseEntidad(string nombre)
    {
        this.Nombre = nombre;
        this.Id = Guid.NewGuid();
    }
}