using System.Threading.Tasks;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Models.Servicios.Peliculas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ILogger<GenerosController> _logger;
        private readonly IGenerosFlujo _generosFlujo;

        public GenerosController(ILogger<GenerosController> logger, IGenerosFlujo generosFlujo)
        {
            _logger = logger;
            _generosFlujo = generosFlujo;
        }

        [HttpGet("peliculas")]
        public async Task<ActionResult<List<Genero>>> GetGenerosPeliculas()
        {
            var resultado = await _generosFlujo.ObtenerGenerosPeliculas();
            if (resultado == null || resultado.Count == 0)
            {
                return NotFound("No se encontraron géneros de películas.");
            }
            return Ok(resultado);
        }

        [HttpGet("series")]
        public async Task<ActionResult> ObtenerGenerosSeries()
        {
            var resultado = await _generosFlujo.ObtenerGenerosSeries();
            if (resultado == null || resultado.Count == 0)
            {
                return NotFound("No se encontraron géneros de series.");
            }
            return Ok(resultado);
        }
    }
}