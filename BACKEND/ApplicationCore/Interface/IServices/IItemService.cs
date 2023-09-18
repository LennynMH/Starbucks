using Domain.Core;
using Domain.DTO.Response.Item;

namespace ApplicationCore.Interface.IServices
{
    public interface IItemService
    {
        Task<HttpResponseResult<ItemListarByIdResponse>> ListarById(int IdItem);
        Task<HttpResponseResult<List<ItemListarResponse>>> Listar();
        Task<HttpResponseResult<int>> Eliminar(int IdItem);
    }
}
