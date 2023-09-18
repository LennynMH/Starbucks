using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories
{
    public class AccesoRepository : MsSqlServer, IAccesoRepository
    {
        public AccesoRepository(IConfiguration configuration)
        : base(configuration)
        {
        }
        //public async Task<UsuarioEntity?> ValidaAccesoUsuario(string Codigo, string Contrasena)
        //{
        //    using (var dbConnection = ObtenerConexion())
        //    {
        //        var result = await dbConnection.QueryAsync<UsuarioEntity, RolEntity, UsuarioEntity>
        //        (ConstStoreProcedure.Acceso.USP_SELECT_USUARIO_BY_ACCESO,
        //        (usuario, Rol) =>
        //        {
        //            usuario.Rol = Rol;
        //            return usuario;
        //        },
        //        new
        //        {
        //            Codigo,
        //            Contrasena
        //        },
        //        splitOn: "IdRol",
        //        commandType: CommandType.StoredProcedure);
        //        return result.FirstOrDefault();
        //    }
        //}
    }
}
