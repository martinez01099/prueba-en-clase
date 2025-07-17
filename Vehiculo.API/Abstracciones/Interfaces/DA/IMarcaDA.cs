using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IMarcasDA
    {
        Task<IEnumerable<MarcaResponse>> Obtener();

        Task<MarcaResponse> Obtener(Guid id);

        Task<Guid> Agregar(MarcaBase marca);

        Task<Guid> Editar(Guid id, MarcaBase marca);

        Task<Guid> Eliminar(Guid id);
    }
}

