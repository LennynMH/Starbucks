using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IMateriaPrimaRepository
    {
        Task<IEnumerable<MateriaPrimaEntity>?> Listar();
        Task<int> Eliminar(MateriaPrimaEntity param);
    }
}
