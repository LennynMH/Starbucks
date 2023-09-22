using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Item;
using Domain.DTO.Request.ItemMateriaPrima;
using Domain.DTO.Response.Item;
using Domain.DTO.Response.Rol;
using Domain.Entities;

namespace ApplicationCore.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(
            IItemRepository itemRepository
           , IMapper mapper)
        {
            this._itemRepository = itemRepository;
            this._mapper = mapper;
        }

        public async Task<HttpResponseResult<int>> Registrar(ItemRegistrarRequest param)
        {
            var parammapper = _mapper.Map<ItemEntity>(param);

            var parammapperDetalle = _mapper.Map<List<ItemMateriaPrimaRegisrtarRequest>>(param.ListItemMateriaPrimaEntity);
            var responsemapper = await _itemRepository.Registrar(parammapper, parammapperDetalle);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Actualizar(ItemRegistrarRequest param)
        {
            var parammapper = _mapper.Map<ItemEntity>(param);

            var parammapperDetalle = _mapper.Map<List<ItemMateriaPrimaRegisrtarRequest>>(param.ListItemMateriaPrimaEntity);
            var responsemapper = await _itemRepository.Actualizar(parammapper, parammapperDetalle);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<List<ItemListarResponse>>> Listar()
        {
            var result = await this._itemRepository.Listar();
            var responsemapper = _mapper.Map<IEnumerable<ItemListarResponse>>(result);
            var response = new HttpResponseResult<List<ItemListarResponse>>() { Data = responsemapper.ToList<ItemListarResponse>() };
            return response;
        }

        public async Task<HttpResponseResult<int>> Eliminar(int IdItem)
        {
            var param = new ItemEliminarRequest { IdItem = IdItem };
            var parammapper = _mapper.Map<ItemEntity>(param);
            var responsemapper = await _itemRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<ItemListarByIdResponse>> ListarById(int IdItem)
        {
            var result = await this._itemRepository.ListarById(IdItem);
            var responsemapper = _mapper.Map<ItemListarByIdResponse>(result);
            var response = new HttpResponseResult<ItemListarByIdResponse>() { Data = responsemapper };
            return response;
        }
    }
}
