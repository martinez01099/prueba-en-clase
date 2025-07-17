using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Models;
using Microsoft.AspNetCore.Mvc;

namespace Peliculas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase, IUsuariosController
    {
        private readonly IUsuariosFlujo _usuariosFlujo;
        public UsuariosController(IUsuariosFlujo usuariosFlujo)
        {
            _usuariosFlujo = usuariosFlujo;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserLogin usuario)
        {
            var resultado = await _usuariosFlujo.Login(usuario);
            if (resultado.ValidationSuccess == true)
            {
                return Ok(resultado);
            }
            else
            {
                return Unauthorized(resultado);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]UserRegister usuario)
        {
            var resultado = await _usuariosFlujo.Register(usuario);
            if (resultado)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest(resultado);
            }
        }
    }
}
