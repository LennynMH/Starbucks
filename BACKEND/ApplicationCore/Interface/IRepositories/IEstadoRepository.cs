using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IEstadoRepository
    {
        Task<int> Registrar(EstadoEntity param);
        Task<int> Actualizar(EstadoEntity param);
        Task<int> Eliminar(EstadoEntity param);
        Task<IEnumerable<EstadoEntity>?> Listar();
        Task<EstadoEntity?> ListarById(int IdEstado);
    }
}
