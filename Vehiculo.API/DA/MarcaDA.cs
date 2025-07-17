using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class MarcasDA : IMarcasDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor
        public MarcasDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(MarcaBase marca)
        {
            string query = @"AgregarMarcas";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Nombre = marca.Nombre
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, MarcaBase marca)
        {
            await verificarMarcaExiste(Id);
            string query = @"EditarMarcas";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = marca.Nombre
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarMarcaExiste(Id);
            string query = @"EliminarMarca";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<MarcaResponse>> Obtener()
        {
            string query = @"ObtenerMarcas";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MarcaResponse>(query);
            return resultadoConsulta;
        }

        public async Task<MarcaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerMarca";
            var resultadoConsulta = await _sqlConnection.QueryAsync<MarcaResponse>(query, new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarMarcaExiste(Guid Id)
        {
            MarcaResponse? resultado = await Obtener(Id);
            if (resultado == null)
                throw new Exception("Marca no encontrada");
        }
        #endregion
    }
}
