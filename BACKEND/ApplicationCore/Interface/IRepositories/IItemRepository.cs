using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>?> Listar();
        Task<int> Eliminar(ItemEntity param);
    }
}
