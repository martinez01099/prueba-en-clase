using Microsoft.AspNetCore.Mvc;
using Abstracciones.Models;
using System.Collections.Generic;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.API;

namespace Peliculas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaVisualizacionController : ControllerBase , IListaVisualizacionController
    {
        private readonly IListaVisualizacionFlujo _listaVisualizacionFlujo;
        private readonly ILogger<ListaVisualizacionController> _logger;
        public ListaVisualizacionController(IListaVisualizacionFlujo listaVisualizacionFlujo, ILogger<ListaVisualizacionController> logger)
        {
            _listaVisualizacionFlujo = listaVisualizacionFlujo;
            _logger = logger;
        }
        [HttpPost("/AgregarContenido")]
        public async Task<ActionResult> AgregarContenidoListaVisualizacion([FromBody]ContenidoListaVisualizacionRequest contenidoListaVisualizacion)
        {
            var resultado = await _listaVisualizacionFlujo.AgregarContenidoListaVisualizacion(contenidoListaVisualizacion);
            return CreatedAtAction(nameof(ObtenerContenidoListaVisualizacion), new { idLista = contenidoListaVisualizacion.IdListaVisualizacion }, resultado);
        }
        [HttpPost("/CrearLista")]
        public async Task<ActionResult> CrearListaVisualizacion([FromBody]ListaVisualizacionCrearObtener listaVisualizacion)
        {
            var resultado = await _listaVisualizacionFlujo.CrearListaVisualizacion(listaVisualizacion);
            return CreatedAtAction(nameof(ObtenerListaVisualizacion), new { idUsuario = listaVisualizacion.IdUsuario }, resultado);
        }
        [HttpGet("ObtenerContenido/{IdLista}")]
        public async Task<ActionResult> ObtenerContenidoListaVisualizacion(Guid IdLista)
        {
            var resultado = await _listaVisualizacionFlujo.ObtenerContenidoListaVisualizacion(IdLista);
            if (resultado == null)
            {
                return NoContent();
            }
            return Ok(resultado);
        }
        [HttpGet("ObtenerLista/{idUsuario}")]
        public async Task<ActionResult> ObtenerListaVisualizacion(Guid idUsuario)
        {
            var resultado = await _listaVisualizacionFlujo.ObtenerListaVisualizacion(idUsuario);
            if (resultado == null)
            {
                return NoContent();
            }
            return Ok("IdLista : " + resultado.IdListaVisualizacion);
        }
    }
}
