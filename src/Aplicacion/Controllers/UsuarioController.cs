using Aplicacion.Properties;
using Aplicacion.ViewModels;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    public AplicacionDbContext context { get; }
    public UsuarioController(AplicacionDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var usuarios = context.Usuarios;

        return Ok(usuarios);
    }

    [HttpPost]
    public ActionResult Post([FromBody] UsuarioViewModel usuario)
    {
        var nuevoUsuario = new Usuario(usuario.Nombre, usuario.Contraseña);

        context.Usuarios.Add(nuevoUsuario);

        context.SaveChanges();

        return Ok(nuevoUsuario);
    }

    [HttpPut]
    public ActionResult Put([FromBody] UsuarioViewModel usuario, Guid id)
    {
        var usuarioConCambios = context.Usuarios.FirstOrDefault(x => x.Id == id);

        usuarioConCambios.Nombre = usuario.Nombre;

        usuarioConCambios.Contraseña = usuario.Contraseña;

        context.SaveChanges();

        return Ok(usuarioConCambios);
    }

    [HttpDelete]
    public ActionResult Delete(Guid id)
    {
        var usuarioABorrar = context.Usuarios.FirstOrDefault(x => x.Id == id);

        context.Usuarios.Remove(usuarioABorrar);

        context.SaveChanges();

        return Ok();
    }

    [HttpPost]
    [Route("{idUsuario}/Rol/{idRol}")]
    public ActionResult AsignarRol(Guid idUsuario, Guid idRol)
    {
        var usuario = context.Usuarios.FirstOrDefault(x => x.Id == idUsuario);

        var rol = context.Roles.FirstOrDefault(x => x.Id == idRol);

        usuario.AsignarUn(rol);

        context.SaveChanges();

        return Ok();
    }

}