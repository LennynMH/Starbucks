using Domain.Core;
using Domain.DTO.Request.Rol;
using Domain.DTO.Response.Rol;
using Domain.Entities;

namespace ApplicationCore.Interface.IServices
{
    public interface IRolService
    {
        Task<HttpResponseResult<int>> Registrar(RolRegistrarRequest param);
        Task<HttpResponseResult<int>> Actualizar(RolActualizarRequest param);
        Task<HttpResponseResult<int>> Eliminar(RolEliminarRequest param);
        Task<HttpResponseResult<List<RolListarResponse>>> Listar();
        Task<HttpResponseResult<RolListarByIdResponse>> ListarById(int IdRol);
    }
}
