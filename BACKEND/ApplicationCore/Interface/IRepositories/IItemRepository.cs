using Domain.DTO.Response.Item;
using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IItemRepository
    {
        Task<ItemListarByIdResponse?> ListarById(int IdItem);
        Task<IEnumerable<ItemEntity>?> Listar();
        Task<int> Eliminar(ItemEntity param);
    }
}
