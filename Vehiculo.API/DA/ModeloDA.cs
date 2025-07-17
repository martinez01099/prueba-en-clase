using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
namespace DA
{
    public class ModeloDA : IModeloDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor
        public ModeloDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(ModeloRequest modelo)
        {
            var existente = await ObtenerPorNombre(modelo.Nombre);
            if (existente != null)
                throw new Exception("Ya existe un modelo con ese nombre.");

            string query = @"AgregarModelo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Idmarca = modelo.IdMarca,
                Nombre = modelo.Nombre
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, ModeloRequest modelo)
        {
            await verificarModeloExite(Id);

            var existente = await ObtenerPorNombre(modelo.Nombre);
            if (existente != null && existente.Id != Id)
                throw new Exception("Ya existe un modelo con ese nombre");

            string query = @"EditarModelo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Idmarca = modelo.IdMarca,
                Nombre = modelo.Nombre
            });

            return resultadoConsulta;
        }



        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarModeloExite(Id);
            String query = @"EliminarModelo";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id

            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<ModeloResponse>> Obtener()
        {
            String query = @"ObtenerModelos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ModeloResponse>(query);
            return resultadoConsulta;
        }

        public async Task<ModeloResponse> Obtener(Guid Id)
        {
            String query = @"ObtenerModelo";

            var resultadoConsulta = await _sqlConnection.QueryAsync<ModeloResponse>(query, new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<ModeloResponse?> ObtenerPorNombre(string nombre)
        {
            string query = @"ObtenerModeloNombre";

            var resultadoConsulta = await _sqlConnection.QueryFirstOrDefaultAsync<ModeloResponse>(query,new { Nombre = nombre }
            );

            return resultadoConsulta;
        }


        #endregion

        #region Helpers
        private async Task verificarModeloExite(Guid Id)
        {
            ModeloResponse? resultadoConsultaModelo = await Obtener(Id);
            if (resultadoConsultaModelo == null)
                throw new Exception("Vehiculo no encontrado");
        }


        #endregion
    }
}
