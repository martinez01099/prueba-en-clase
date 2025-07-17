using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PeliculasController : ControllerBase, IPeliculasController
    {
        private readonly ILogger<PeliculasController> _logger;
        private readonly IPeliculasFlujo _peliculasFlujo;

        public PeliculasController(ILogger<PeliculasController> logger, IPeliculasFlujo peliculasFlujo)
        {
            _logger = logger;
            _peliculasFlujo = peliculasFlujo;
        }
        [HttpGet("{generoId}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> ObtenerPeliculas([FromRoute]int generoId)
        {
            var resultado = await _peliculasFlujo.ObtenerPeliculas(generoId);
            if (resultado.IsNullOrEmpty())
            {
                return NotFound("El genero no existe");
            }
            return Ok(resultado);



        }
    }
}
