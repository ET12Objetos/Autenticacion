using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public UsuarioController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var usuarios = contexto.Usuarios;
        return Ok(usuarios);
    }

    [HttpGet]
    public ActionResult Get(Guid id)
    {
        var usuario = contexto.Usuarios.FirstOrDefault(x => x.Id == id);
        return Ok(usuario);
    }

    [HttpPost]
    public ActionResult Post([FromBody] UsuarioViewModel usuario)
    {
        var nuevoUsuario = new Usuario(usuario.Nombre, usuario.Contraseña);
        contexto.Add(nuevoUsuario);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }
}