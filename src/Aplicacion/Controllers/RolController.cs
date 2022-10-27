using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Properties;
using Aplicacion.ViewModels;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        public AplicacionDbContext context { get; }
        public RolController(AplicacionDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ActionResult Post([FromBody] RolViewModel rol)
        {
            var nuevoRol = new Rol(rol.Nombre);

            context.Roles.Add(nuevoRol);

            context.SaveChanges();

            return Ok(nuevoRol);
        }
    }
}