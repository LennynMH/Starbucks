using Domain.DTO.Request.ItemMateriaPrima;
using Domain.DTO.Response.Item;
using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IItemRepository
    {
        Task<int> Registrar(ItemEntity param, List<ItemMateriaPrimaRegisrtarRequest> listItemMateriaPrimaEntities);
        Task<int> Actualizar(ItemEntity param, List<ItemMateriaPrimaRegisrtarRequest> listItemMateriaPrimaEntities);
        Task<ItemListarByIdResponse?> ListarById(int IdItem);
        Task<IEnumerable<ItemEntity>?> Listar();
        Task<int> Eliminar(ItemEntity param);
    }
}
