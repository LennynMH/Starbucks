using Domain.Core;
using Domain.DTO.Response.Estado;

namespace ApplicationCore.Interface.IServices
{
    public interface IEstadoService
    {
        Task<HttpResponseResult<int>> Registrar(EstadoRegistrar param);
        Task<HttpResponseResult<int>> Actualizar(EstadoActualizar param);
        Task<HttpResponseResult<int>> Eliminar(EstadoEliminar param);
        Task<HttpResponseResult<List<EstadoListarDto>>> Listar();
        Task<HttpResponseResult<EstadoListarByIdDto>> ListarById(int IdEstado);
    }
}
