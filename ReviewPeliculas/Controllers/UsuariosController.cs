using System;
using ReviewPeliculas.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReviewPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //localhost:8080/api/all
        // GET: api/<UsuariosController>/all

        [ HttpGet ("all")]
        public JsonResult ObtenerUsuarios()
        {
            var usuariosRecibidos = UsuarioAzure.ObtenerUsuarios();
            return new JsonResult(usuariosRecibidos);

        }

            

    }
}
