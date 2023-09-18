using Domain.Core;
using Domain.DTO.Response.Usuario;

namespace ApplicationCore.Interface.IServices
{
    public interface IUsuarioService
    {
        Task<HttpResponseResult<UsuarioListarByCodigoResponse>> ListarByCodigo(string? Codigo);
    }
}
