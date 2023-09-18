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
    public class UsuarioRepository : MsSqlServer, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration)
        : base(configuration)
        {
        }

        public async Task<UsuarioEntity?> ListarByCodigo(string? Codigo)
        {
            /*
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<UsuarioEntity>(
                  ConstStoreProcedure.Usuario.USP_SELECT_USUARIO_BY_CODIGO,
                  new
                  {
                      Codigo
                  }, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            */
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<UsuarioEntity, RolEntity, UsuarioEntity>
                (ConstStoreProcedure.Usuario.USP_SELECT_USUARIO_BY_CODIGO,
                (usuario, Rol) =>
                {
                    usuario.Rol = Rol;
                    return usuario;
                },
                new
                {
                    Codigo
                },
                splitOn: "IdRol",
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
    }
}
