using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolController : ControllerBase
{
    public AplicacionDbContext context { get; }
    public RolController(AplicacionDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var roles = context.Roles;

        return Ok(roles);
    }

    [HttpPost]
    public ActionResult Post([FromBody] RolViewModel rol)
    {
        var nuevoRol = new Rol(rol.Nombre);

        context.Roles.Add(nuevoRol);

        context.SaveChanges();

        return Ok(nuevoRol);
    }

    [HttpPut("{id:Guid}")]
    public ActionResult Put([FromBody] RolViewModel rol, Guid id)
    {
        var rolConCambios = context.Roles.FirstOrDefault(x => x.Id == id);

        rolConCambios.Actualizar(rol.Nombre);

        context.SaveChanges();

        return Ok(rolConCambios);
    }

    [HttpDelete("{id:Guid}")]
    public ActionResult Delete(Guid id)
    {
        var rolABorrar = context.Roles.FirstOrDefault(x => x.Id == id);

        context.Roles.Remove(rolABorrar);

        context.SaveChanges();

        return Ok();
    }

    [HttpPost]
    [Route("{id}/Usuario/{idUsuario}")]
    public ActionResult AsignarUsuario(Guid id, Guid idUsuario)
    {
        var usuario = context.Usuarios.FirstOrDefault(x => x.Id == idUsuario);

        var rol = context.Roles.FirstOrDefault(x => x.Id == id);

        rol.AsignarA(usuario);

        context.SaveChanges();

        return Ok();
    }
}