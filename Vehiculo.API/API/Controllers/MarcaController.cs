using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase, IMarcaController
    {
        private IMarcaFlujo _marcaFlujo;
        private ILogger<MarcaController> _logger;

        public MarcaController(IMarcaFlujo marcaFlujo, ILogger<MarcaController> logger)
        {
            _marcaFlujo = marcaFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(MarcaBase marca)
        {
            var resultado = await _marcaFlujo.Agregar(marca);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, MarcaBase marca)
        {
            var resultado = await _marcaFlujo.Editar(Id, marca);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            var resultado = await _marcaFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _marcaFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            var resultado = await _marcaFlujo.Obtener(Id);
            return Ok(resultado);
        }
    }
}
