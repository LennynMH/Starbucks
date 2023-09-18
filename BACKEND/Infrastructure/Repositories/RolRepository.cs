using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace Infrastructure.Repositories
{
    public class RolRepository : MsSqlServer, IRolRepository
    {
        public RolRepository(IConfiguration configuration)
       : base(configuration)
        {
        }
        public async Task<int> Registrar(RolEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>(ConstStoreProcedure.Rol.USP_CREATE_ROL,
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

        public async Task<int> Actualizar(RolEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>(ConstStoreProcedure.Rol.USP_UPDATE_ROL,
                           new
                           {
                               param.IdRol,
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

        public async Task<int> Eliminar(RolEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.ExecuteAsync(ConstStoreProcedure.Rol.USP_DELETE_ROL,
                           new
                           {
                               param.IdRol,
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

        public async Task<IEnumerable<RolEntity>?> Listar()
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<RolEntity>(
                  ConstStoreProcedure.Rol.USP_SELECT_ROL,
                  new
                  {
                  }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<RolEntity?> ListarById(int IdRol)
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<RolEntity>(
                ConstStoreProcedure.Rol.USP_SELECT_ROL_BY_ID,
                  new
                  {
                      IdRol
                  }, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
    }
}
