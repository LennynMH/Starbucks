using ApplicationCore.Interface.IRepositories;
using Dapper;
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Conecction.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : MsSqlServer, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration)
        : base(configuration)
        {
        }

        public async Task<int> Registrar(UsuarioEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>(ConstStoreProcedure.Usuario.USP_CREATE_USUARIO,
                            new
                            {
                                param.Rol.IdRol,
                                param.DocumentoIdentidad,
                                param.Nombre,
                                param.Apellido,
                                param.Edad,
                                param.Sexo,
                                param.Correo,
                                param.Codigo,
                                param.Contrasena,
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

        public async Task<int> Actualizar(UsuarioEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.QuerySingleAsync<int>(ConstStoreProcedure.Usuario.USP_UPDATE_USUARIO,
                           new
                           {
                               param.IdUsuario,
                               param.Rol.IdRol,
                               param.DocumentoIdentidad,
                               param.Nombre,
                               param.Apellido,
                               param.Edad,
                               param.Sexo,
                               param.Correo,
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

        public async Task<int> Eliminar(UsuarioEntity param)
        {
            int result;
            using (var dbConnection = ObtenerConexion())
            {
                dbConnection.Open();
                using (var dbtransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        result = await dbConnection.ExecuteAsync(ConstStoreProcedure.Usuario.USP_DELETE_USUARIO,
                           new
                           {
                               param.IdUsuario,
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

        public async Task<IEnumerable<UsuarioEntity>?> Listar(UsuarioEntity param)
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<UsuarioEntity, RolEntity, UsuarioEntity>
                (ConstStoreProcedure.Usuario.USP_SELECT_USUARIO,
                (usuario, Rol) =>
                {
                    usuario.Rol = Rol;
                    return usuario;
                },
                new
                {
                    param.Rol.IdRol
                },
                splitOn: "IdRol",
                commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<UsuarioEntity?> ListarById(int IdUsuario)
        {
            using (var dbConnection = ObtenerConexion())
            {
                var result = await dbConnection.QueryAsync<UsuarioEntity, RolEntity, UsuarioEntity>
                (ConstStoreProcedure.Usuario.USP_SELECT_USUARIO_BY_ID,
                (usuario, Rol) =>
                {
                    usuario.Rol = Rol;
                    return usuario;
                },
                new
                {
                    IdUsuario
                },
                splitOn: "IdRol",
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<UsuarioEntity?> ListarByCodigo(string? Codigo)
        {
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
