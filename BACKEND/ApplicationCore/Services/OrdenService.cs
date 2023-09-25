using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Orden;
using Domain.DTO.Request.OrdenItem;
using Domain.DTO.Response.Orden;
using Domain.Entities;

namespace ApplicationCore.Services
{
    public class OrdenService : IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IMapper _mapper;
        public OrdenService(
            IOrdenRepository ordenRepository
           , IMapper mapper)
        {
            this._ordenRepository = ordenRepository;
            this._mapper = mapper;
        }

        public async Task<HttpResponseResult<int>> Registrar(OrdenRegistrarRequest param)
        {
            var parammapper = _mapper.Map<OrdenEntity>(param);
            var parammapperDetalle = _mapper.Map<List<OrdenItemRegistrarRequest>>(param.ListOrdenItem);
            var responsemapper = await _ordenRepository.Registrar(parammapper, parammapperDetalle);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }
        public async Task<HttpResponseResult<int>> Actualizar(OrdenRegistrarRequest param)
        {
            var parammapper = _mapper.Map<OrdenEntity>(param);
            var parammapperDetalle = _mapper.Map<List<OrdenItemRegistrarRequest>>(param.ListOrdenItem);
            var responsemapper = await _ordenRepository.Actualizar(parammapper, parammapperDetalle);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<List<OrdenListarResponse>>> Listar(OrdenListarRequest query)
        {
            var requestmapper = _mapper.Map<OrdenEntity>(query);
            var result = await this._ordenRepository.Listar(requestmapper);
            var responsemapper = _mapper.Map<IEnumerable<OrdenListarResponse>>(result);
            var response = new HttpResponseResult<List<OrdenListarResponse>>() { Data = responsemapper.ToList<OrdenListarResponse>() };
            return response;
        }

        public async Task<HttpResponseResult<OrdenListarByIdResponse>> ListarById(int IdOrden)
        {
            var result = await this._ordenRepository.ListarById(IdOrden);
            var responsemapper = _mapper.Map<OrdenListarByIdResponse>(result);
            var response = new HttpResponseResult<OrdenListarByIdResponse>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Eliminar(OrdenEliminarRequest param)
        {
            var parammapper = _mapper.Map<OrdenEntity>(param);
            var responsemapper = await _ordenRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }
    }
}
