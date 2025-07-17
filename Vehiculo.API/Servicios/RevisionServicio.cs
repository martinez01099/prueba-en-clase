﻿using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System.Net.Http;
using System.Text.Json;


namespace Servicios
{
    public class RevisionServicio : IRevisionServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public RevisionServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Revision> Obtener(string placa)
        {
            var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsRevision", "ObtenerRevision");
            var servicioRevision=_httpClient.CreateClient("ServicioRevision");
            var respuesta=await servicioRevision.GetAsync(string.Format(endpoint,placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
