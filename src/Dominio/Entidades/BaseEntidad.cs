namespace Dominio.Entidades;

public abstract class BaseEntidad
{
    public Guid Id { get; protected set; }
    public string Nombre { get; protected set; }
    public bool Habilitado { get; protected set; } = false;

    public BaseEntidad(string nombre)
    {
        this.Nombre = nombre;
        this.Id = Guid.NewGuid();
    }
}