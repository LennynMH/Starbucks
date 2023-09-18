using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity?> ListarByCodigo(string Codigo);
    }
}
