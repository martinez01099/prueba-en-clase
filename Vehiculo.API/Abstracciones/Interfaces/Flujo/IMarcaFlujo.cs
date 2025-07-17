using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IMarcaFlujo
    {
        Task<IEnumerable<MarcaResponse>> Obtener();

        Task<MarcaResponse> Obtener(Guid id);

        Task<Guid> Agregar(MarcaBase marca);

        Task<Guid> Editar(Guid id, MarcaBase marca);

        Task<Guid> Eliminar(Guid id);
    }
}
