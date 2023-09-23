using Domain.Core;
using Domain.DTO.Request.Orden;
using Domain.DTO.Response.Orden;

namespace ApplicationCore.Interface.IServices
{
    public interface IOrdenService
    {
        Task<HttpResponseResult<int>> Registrar(OrdenRegistrarRequest param);
        Task<HttpResponseResult<int>> Actualizar(OrdenRegistrarRequest param);
        Task<HttpResponseResult<List<OrdenListarResponse>>> Listar();
        Task<HttpResponseResult<OrdenListarByIdResponse>> ListarById(int IdOrden);
        Task<HttpResponseResult<int>> Eliminar(OrdenEliminarRequest param);
    }
}
