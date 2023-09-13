using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IRolRepository
    {
        Task<int> Registrar(RolEntity param);
        Task<int> Actualizar(RolEntity param);
        Task<int> Eliminar(RolEntity param);
        Task<IEnumerable<RolEntity>?> Listar();
        Task<RolEntity?> ListarById(int IdRol);
    }
}
