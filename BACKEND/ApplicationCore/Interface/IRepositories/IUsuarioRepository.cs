using Domain.Entities;

namespace ApplicationCore.Interface.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<int> Registrar(UsuarioEntity param);
        Task<int> Actualizar(UsuarioEntity param);
        Task<int> Eliminar(UsuarioEntity param);
        Task<IEnumerable<UsuarioEntity>?> Listar(UsuarioEntity param);
        Task<UsuarioEntity?> ListarById(int IdUsuario);
        Task<UsuarioEntity?> ListarByCodigo(string Codigo);
    }
}
