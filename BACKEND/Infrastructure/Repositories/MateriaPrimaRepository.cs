using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MateriaPrimaRepository : MsSqlServer, IMateriaPrimaRepository
    {
        public MateriaPrimaRepository(IConfiguration configuration)
        : base(configuration)
        {
        }
        public async Task<IEnumerable<MateriaPrimaEntity>?> Listar()
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<MateriaPrimaEntity>(
                   ConstStoreProcedure.MateriaPrima.USP_SELECT_MATERIA_PRIMA,
                  new
                  {
                  }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> Eliminar(MateriaPrimaEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.ExecuteAsync(ConstStoreProcedure.MateriaPrima.USP_DELETE_MATERIA_PRIMA,
                           new
                           {
                               param.IdMateriaPrima,
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

    }
}
