using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase , ISeriesController
    {
        private ILogger _logger;
        private ISeriesFlujo _seriesFlujo;

        public SeriesController(ILogger<SeriesController> logger, ISeriesFlujo seriesFlujo)
        {
            _logger = logger;
            _seriesFlujo = seriesFlujo;
        }
        [HttpGet("{IdGenero}")]
        public async Task<ActionResult> Obtener([FromRoute]int IdGenero)
        {
           var resultado = await _seriesFlujo.Obtener(IdGenero);
            if (resultado == null)
            {
               return NotFound("Este genero no posee series registradas.");
            }
            return Ok(resultado);
        }
    }
}
