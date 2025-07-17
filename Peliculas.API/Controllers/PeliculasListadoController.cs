using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Peliculas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PeliculasListadoController : ControllerBase, IPeliculasListadoController
    {
        private readonly ILogger<PeliculasListadoController> _logger;
        private readonly IPeliculasListadoFlujo _peliculas;

        public PeliculasListadoController(ILogger<PeliculasListadoController> logger, IPeliculasListadoFlujo peliculas)
        {
            _logger = logger;
            _peliculas = peliculas;
        }
        [HttpPost("actualizarPelicula")]
        public Task<IActionResult> actualizarPelicula(ListadoPeliculas listado)
        {
            throw new NotImplementedException();
        }

        [HttpPost("agregarPelicula/{peliculaId}/{usuarioId}")]
        public Task<IActionResult> agregarPelicula(Guid peliculaId, string usuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("eliminarPelicula/{peliculaId}/{usuarioId}")]
        public Task<IActionResult> eliminarPelicula(Guid peliculaId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("peliculaObtener")]
        public Task<IActionResult> peliculaObtener(ListadoPeliculas listado)
        {
            throw new NotImplementedException();
        }

        [HttpGet("peliculasListar/{usuarioId}")]
        public async Task<IActionResult> peliculasListar([FromRoute]string usuarioId)
        {
           var resultado = await _peliculas.peliculasListar(usuarioId);
            if (resultado.IsNullOrEmpty())
            {
                return Ok(resultado);
            }
            return Ok(resultado);
        }
    }
}
