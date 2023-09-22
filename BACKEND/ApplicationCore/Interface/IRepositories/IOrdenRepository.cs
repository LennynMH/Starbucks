using Domain.DTO.Response.Orden;
using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IOrdenRepository
    {
        Task<IEnumerable<OrdenEntity>?> Listar();
        Task<OrdenListarByIdResponse?> ListarById(int IdOrden);
        Task<int> Eliminar(OrdenEntity param);
    }
}
