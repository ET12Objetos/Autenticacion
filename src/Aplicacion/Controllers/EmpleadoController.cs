using Aplicacion.Properties;
using Aplicacion.ViewModels;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly AplicacionDbContext context;
    public EmpleadoController(AplicacionDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var empleados = context.Empleados;

        return Ok(empleados);
    }

    [HttpPost]
    public ActionResult Post([FromBody] EmpleadoViewModel empleado)
    {
        var nuevoEmpleado = new Empleado(empleado.Nombre, empleado.Apellido, empleado.Email);

        context.Empleados.Add(nuevoEmpleado);

        context.SaveChanges();

        return Ok(nuevoEmpleado);
    }

    [HttpPut("{id:Guid}")]
    public ActionResult Put([FromBody] EmpleadoViewModel empleado, Guid id)
    {
        var empleadoAModificar = context.Empleados.FirstOrDefault(x => x.Id == id);

        empleadoAModificar.Actualizar(empleado.Nombre, empleado.Apellido, empleado.Email);

        context.SaveChanges();

        return Ok(empleadoAModificar);
    }

    [HttpDelete("{id:Guid}")]
    public ActionResult Delete(Guid id)
    {
        var empleadoABorrar = context.Empleados.FirstOrDefault(x => x.Id == id);

        context.Empleados.Remove(empleadoABorrar);

        context.SaveChanges();

        return Ok();
    }

    [HttpPost]
    [Route("{id}/Usuario/{idUsuario}")]
    public ActionResult AsignarUsuario(Guid id, Guid idUsuario)
    {
        var empleado = context.Empleados.FirstOrDefault(x => x.Id == id);

        var usuario = context.Usuarios.FirstOrDefault(x => x.Id == idUsuario);

        empleado.AsignarUn(usuario);

        context.SaveChanges();

        return Ok();
    }
}