using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.Interfaces.API
{
    public interface IModeloController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);

        Task<IActionResult> Agregar(ModeloRequest marca);

        Task<IActionResult> Editar(Guid Id, ModeloRequest marca);

        Task<IActionResult> Eliminar(Guid Id);
    }
}
