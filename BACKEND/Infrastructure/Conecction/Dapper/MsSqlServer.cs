using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Conecction.Dapper
{
    public class MsSqlServer : BaseConecction
    {
        public MsSqlServer(IConfiguration _configuration) : base(_configuration)
        {

        }

        public static IDbConnection ObtenerConexion()
        {
            var connectionStringName = string.Empty;

            connectionStringName = string.Format("ConnectionStrings:{0}", "ConexionSvr_Default");

            var connectionString = DapperConfiguration[connectionStringName];

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("El parámetro connectionString se encuentra nulo.");

            var sqlConnection = new SqlConnectionStringBuilder(connectionString);

            var connection = new SqlConnection(sqlConnection.ConnectionString);

            return connection;
        }
    }
}
