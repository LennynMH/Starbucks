using Domain.DTO.Response.Item;
using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IItemRepository
    {
        Task<int> Registrar(ItemEntity param, List<ItemMateriaPrimaEntity> listItemMateriaPrimaEntities);
        Task<ItemListarByIdResponse?> ListarById(int IdItem);
        Task<IEnumerable<ItemEntity>?> Listar();
        Task<int> Eliminar(ItemEntity param);
    }
}
