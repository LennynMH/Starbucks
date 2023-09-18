using Domain.Core;
using Domain.DTO.Request.Usuario;
using Domain.DTO.Response.Usuario;

namespace ApplicationCore.Interface.IServices
{
    public interface IUsuarioService
    {
        Task<HttpResponseResult<int>> Registrar(UsuarioRegistrarRequest param);
        Task<HttpResponseResult<int>> Actualizar(UsuarioActualizarRequest param);
        Task<HttpResponseResult<int>> Eliminar(int IdUsuario);
        Task<HttpResponseResult<List<UsuarioListarResponse>>> Listar(UsuarioRegistrarRequest param);
        Task<HttpResponseResult<UsuarioListarByIdResponse>> ListarById(int IdUsuario);
        Task<HttpResponseResult<UsuarioListarByCodigoResponse>> ListarByCodigo(string? Codigo);
    }
}
