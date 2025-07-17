
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;


namespace Flujo
{
    public class MarcaFlujo : IMarcaFlujo
    {
        private readonly IMarcasDA _marcasDA;

        public MarcaFlujo(IMarcasDA marcasDA)
        {
            _marcasDA = marcasDA;
        }

        public Task<Guid> Agregar(MarcaBase marca)
        {
            return _marcasDA.Agregar(marca);
        }

        public Task<Guid> Editar(Guid id, MarcaBase marca)
        {
            return _marcasDA.Editar(id, marca);
        }

        public Task<Guid> Eliminar(Guid id)
        {
            return _marcasDA.Eliminar(id);
        }

        public Task<IEnumerable<MarcaResponse>> Obtener()
        {
            return _marcasDA.Obtener();
        }

        public Task<MarcaResponse> Obtener(Guid id)
        {
            return _marcasDA.Obtener(id);
        }
    }
}
