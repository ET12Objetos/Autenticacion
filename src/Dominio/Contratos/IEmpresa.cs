using Dominio.Entidades;

namespace Dominio.Contratos;
public interface IEmpresa
{
    void CrearUsuario(string nombre, string contraseña);
    void CrearEmpleado(string nombre, string apellido, string email);
    void CrearRol(string nombre);

    void ActualizarEmpleado(Guid id, Empleado empleado);
    void ActualizarUsuario(Guid id, Usuario usuario);
    void ActualizarRol(Guid id, Rol rol);

    void EliminarRol(Guid id);
    void EliminarUsuario(Guid id);
    void EliminarEmpleado(Guid id);
}