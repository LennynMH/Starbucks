using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories
{
    public class EstadoRepository : MsSqlServer, IEstadoRepository
    {
        public EstadoRepository(IConfiguration configuration)
        : base(configuration)
        {
        }

        public async Task<int> Registrar(EstadoEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>("USP_CREATE_ESTADO",
                            new
                            {
                                param.Descripcion
                            },
                            transaction: dbtransaction,
                            commandType: CommandType.StoredProcedure);

                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        throw;
                    }
                }
            }
            return result;
        }

        public async Task<int> Actualizar(EstadoEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>("USP_UPDATE_ESTADO",
                           new
                           {
                               param.IdEstado,
                               param.Descripcion,
                           },
                           transaction: dbtransaction,
                           commandType: CommandType.StoredProcedure);

                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        throw;
                    }
                }
            }
            return result;
        }

        public async Task<int> Eliminar(EstadoEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.ExecuteAsync("USP_DELETE_ESTADO",
                           new
                           {
                               param.IdEstado,
                           },
                           transaction: dbtransaction,
                           commandType: CommandType.StoredProcedure);

                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        throw;
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<EstadoEntity>?> Listar()
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<EstadoEntity>(
                  "USP_SELECT_ESTADO",
                  new
                  {
                  }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<EstadoEntity?> ListarById(int IdEstado)
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<EstadoEntity>(
                  "USP_SELECT_ESTADO_BY_ID",
                  new
                  {
                      IdEstado
                  }, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

    }
}
