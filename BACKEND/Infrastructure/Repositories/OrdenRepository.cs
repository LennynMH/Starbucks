using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Constants;
using Domain.DTO.Response.Orden;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories
{
    public class OrdenRepository : MsSqlServer, IOrdenRepository
    {
        public OrdenRepository(IConfiguration configuration)
       : base(configuration)
        {
        }

        public async Task<IEnumerable<OrdenEntity>?> Listar()
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<OrdenEntity, UsuarioEntity, UsuarioEntity, EstadoEntity, OrdenEntity>
                (ConstStoreProcedure.Orden.USP_SELECT_ORDEN,
                (orden, usuario, empleado, estado) =>
                {
                    orden.Usuario = usuario;
                    orden.Empleado = empleado;
                    orden.Estado = estado;
                    return orden;
                },
                new
                { },
                splitOn: "IdUsuario,IdEmpleado,IdEstado",
                commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<OrdenListarByIdResponse?> ListarById(int IdOrden)
        {
            var result = new OrdenListarByIdResponse { };

            using (var dbConnection = ObtenerConexion())
            {
                var reader = await dbConnection.QueryMultipleAsync(
                        ConstStoreProcedure.Orden.USP_SELECT_ORDEN_BY_ID,
                          new
                          {
                              IdOrden
                          },
                        commandType: CommandType.StoredProcedure
                    );

                var orden = reader.Read<OrdenEntity, UsuarioEntity, UsuarioEntity, EstadoEntity, OrdenEntity>((orden, usuario, empleado, estado) =>
                {
                    orden.Usuario = usuario;
                    orden.Empleado = empleado;
                    orden.Estado = estado;
                    return orden;
                },
                  splitOn: "IdUsuario,IdEmpleado,IdEstado").FirstOrDefault();

                var ordenitem = reader.Read<OrdenItemEntity, ItemEntity, OrdenItemEntity>((orden, item) =>
                {
                    orden.Item = item;
                    return orden;
                },
                   splitOn: "IdItem").ToList<OrdenItemEntity>();

                result.Orden = orden;
                result.OrdenItem = ordenitem;
                return result;
            }
        }
        public async Task<int> Eliminar(OrdenEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.ExecuteAsync(ConstStoreProcedure.Orden.USP_DELETE_ORDEN,
                           new
                           {
                               param.IdOrden,
                               param.Estado.IdEstado
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
