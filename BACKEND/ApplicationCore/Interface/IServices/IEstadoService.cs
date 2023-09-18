using Domain.Core;
using Domain.DTO.Request.Estado;
using Domain.DTO.Response.Estado;

namespace ApplicationCore.Interface.IServices
{
    public interface IEstadoService
    {
        Task<HttpResponseResult<int>> Registrar(EstadoRegistrarResquest param);
        Task<HttpResponseResult<int>> Actualizar(EstadoActualizarRequest param);
        Task<HttpResponseResult<int>> Eliminar(EstadoEliminarRequest param);
        Task<HttpResponseResult<List<EstadoListarResponse>>> Listar();
        Task<HttpResponseResult<EstadoListarByIdResponse>> ListarById(int IdEstado);
    }
}
