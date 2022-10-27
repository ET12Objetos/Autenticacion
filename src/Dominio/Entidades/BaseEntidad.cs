using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades;

public abstract class BaseEntidad
{
    [Key]
    [Required]
    public Guid Id { get; protected set; }

    [Required]
    public string Nombre { get; protected set; }

    [Required]
    public bool Habilitado { get; protected set; } = false;

    public BaseEntidad(string nombre)
    {
        this.Nombre = nombre;
        this.Id = Guid.NewGuid();
    }
}