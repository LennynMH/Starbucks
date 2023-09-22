using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Constants;
using Domain.DTO.Request.ItemMateriaPrima;
using Domain.DTO.Response.Item;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories
{
    public class ItemRepository : MsSqlServer, IItemRepository
    {
        public ItemRepository(IConfiguration configuration)
       : base(configuration)
        {
        }

        public async Task<int> Registrar(ItemEntity param, List<ItemMateriaPrimaRegisrtarRequest> listItemMateriaPrimaEntities)
        {
            int result;
            var ListadoItemMateriaPrima = listItemMateriaPrimaEntities.AsTableValuedParameter("listItemMateriaPrima", true, new List<string> { "IdItemMateriPrima", "IdMateriaPrima", "Precio", "Cantidad" });

            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>(ConstStoreProcedure.Item.USP_CREATE_ITEMS,
                            new
                            {
                                param.Descripcion,
                                param.CostoTotal,
                                ListadoItemMateriaPrima
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

        public async Task<int> Actualizar(ItemEntity param, List<ItemMateriaPrimaRegisrtarRequest> listItemMateriaPrimaEntities)
        {
            int result;
            var ListadoItemMateriaPrima = listItemMateriaPrimaEntities.AsTableValuedParameter("listItemMateriaPrima", true, new List<string> { "IdItemMateriPrima", "IdMateriaPrima", "Precio", "Cantidad" });

            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>(ConstStoreProcedure.Item.USP_UPDATE_ITEMS,
                            new
                            {
                                param.IdItem,
                                param.Descripcion,
                                param.CostoTotal,
                                ListadoItemMateriaPrima
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
        public async Task<IEnumerable<ItemEntity>?> Listar()
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<ItemEntity>(
                  ConstStoreProcedure.Item.USP_SELECT_ITEMS,
                  new
                  {
                  }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> Eliminar(ItemEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.ExecuteAsync(ConstStoreProcedure.Item.USP_DELETE_ITEMS,
                           new
                           {
                               param.IdItem,
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
        public async Task<ItemListarByIdResponse?> ListarById(int IdItem)
        {
            var result = new ItemListarByIdResponse { };

            using (var dbConnection = ObtenerConexion())
            {
                var reader = await dbConnection.QueryMultipleAsync(
                        ConstStoreProcedure.Item.USP_SELECT_ITEMS_BY_ID,
                          new
                          {
                              IdItem
                          },
                        commandType: CommandType.StoredProcedure
                    );
                var item = reader.Read<ItemEntity>().FirstOrDefault();
                var itemMateriaPrima = reader.Read<ItemMateriaPrimaEntity, MateriaPrimaEntity, ItemMateriaPrimaEntity>((itemMateria, materia) =>
                {
                    itemMateria.MateriaPrima = materia;
                    return itemMateria;
                },
                   splitOn: "IdMateriaPrima").ToList<ItemMateriaPrimaEntity>();

                result.Item = item;
                result.ItemMateriaPrima = itemMateriaPrima;
                return result;
            }
        }
    }
}
