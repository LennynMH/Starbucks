using Domain.Core;
using Domain.DTO.Response.Rol;
using Domain.Entities;

namespace ApplicationCore.Interface.IServices
{
    public interface IRolService
    {
        Task<HttpResponseResult<int>> Registrar(RolRegistrar param);
        Task<HttpResponseResult<int>> Actualizar(RolActualizar param);
        Task<HttpResponseResult<int>> Eliminar(RolEliminar param);
        Task<HttpResponseResult<List<RolListarDto>>> Listar();
        Task<HttpResponseResult<RolListarByIdDto>> ListarById(int IdRol);
    }
}
