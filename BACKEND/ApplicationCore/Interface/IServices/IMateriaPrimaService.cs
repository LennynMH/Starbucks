using Domain.Core;
using Domain.DTO.Response.MateriaPrima;

namespace ApplicationCore.Interface.IServices
{
    public interface IMateriaPrimaService
    {
        Task<HttpResponseResult<List<MateriaPrimaListarResponse>>> Listar();
        Task<HttpResponseResult<int>> Eliminar(int IdMateriaPrima);
    }
}
