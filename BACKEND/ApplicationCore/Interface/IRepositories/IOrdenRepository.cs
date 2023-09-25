using Domain.DTO.Request.OrdenItem;
using Domain.DTO.Response.Orden;
using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IOrdenRepository
    {
        Task<int> Registrar(OrdenEntity param, List<OrdenItemRegistrarRequest> listOrdenItem);
        Task<int> Actualizar(OrdenEntity param, List<OrdenItemRegistrarRequest> listOrdenItem);
        Task<IEnumerable<OrdenEntity>?> Listar(OrdenEntity param);
        Task<OrdenListarByIdResponse?> ListarById(int IdOrden);
        Task<int> Eliminar(OrdenEntity param);
    }
}
