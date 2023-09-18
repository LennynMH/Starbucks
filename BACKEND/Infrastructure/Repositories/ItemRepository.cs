using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
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

    }
}
