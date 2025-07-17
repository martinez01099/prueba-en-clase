﻿
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IVehiculoController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid id);

        Task<IActionResult> Agregar(VehiculoRequest vehiculo);

        Task<IActionResult> Editar(Guid id, VehiculoRequest vehiculo);

        Task<IActionResult> Eliminar(Guid Id);
    }
}
