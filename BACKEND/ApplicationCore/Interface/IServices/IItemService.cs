using Domain.Core;
using Domain.DTO.Request.Item;
using Domain.DTO.Response.Item;

namespace ApplicationCore.Interface.IServices
{
    public interface IItemService
    {
        Task<HttpResponseResult<int>> Registrar(ItemRegistrarRequest param);
        Task<HttpResponseResult<int>> Actualizar(ItemRegistrarRequest param);
        Task<HttpResponseResult<ItemListarByIdResponse>> ListarById(int IdItem);
        Task<HttpResponseResult<List<ItemListarResponse>>> Listar();
        Task<HttpResponseResult<int>> Eliminar(int IdItem);
    }
}
