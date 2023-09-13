using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Entities;
using Infrastructure.Conecction;
using Infrastructure.Conecction.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class EstadoRepository : MsSqlServer, IEstadoRepository
    {
        public EstadoRepository(IConfiguration configuration)
        : base(configuration)
        {
        }


        //public async Task<int> Registrar(RolEntity param)
        //{
        //    int result;
        //    using (var dbConnection = ObtenerConexion())
        //    {
        //        dbConnection.Open();
        //        using (var tran = dbConnection.BeginTransaction())
        //        {
        //            try
        //            {
        //                result = await dbConnection.QueryFirstAsync<int>(
        //                "USP_CREATE_ROL",
        //                new
        //                {
        //                    param.Descripcion,
        //                },
        //                commandType: CommandType.StoredProcedure
        //                );
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                tran.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
