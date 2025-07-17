﻿using Abstracciones.Modelos;


namespace Abstracciones.Interfaces.Flujo
{
    public interface IVehiculoFlujo
    {
        Task<IEnumerable<VehiculoResponse>> Obtener();
        Task<VehiculoResponse> Obtener(Guid id);

        Task<Guid> Agregar(VehiculoRequest vehiculo);

        Task<Guid> Editar(Guid id, VehiculoRequest vehiculo);

        Task<Guid> Eliminar(Guid Id);
    }
}
