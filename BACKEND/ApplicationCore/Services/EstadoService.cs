using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Estado;
using Domain.DTO.Response.Estado;
using Domain.Entities;

namespace ApplicationCore.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _rolRepository;
        private readonly IMapper _mapper;
        public EstadoService(
           IEstadoRepository rolRepository
           , IMapper mapper)
        {
            this._rolRepository = rolRepository;
            this._mapper = mapper;
        }

        public async Task<HttpResponseResult<int>> Registrar(EstadoRegistrarResquest param)
        {
            var parammapper = _mapper.Map<EstadoEntity>(param);
            var responsemapper = await _rolRepository.Registrar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Actualizar(EstadoActualizarRequest param)
        {
            var parammapper = _mapper.Map<EstadoEntity>(param);
            var responsemapper = await _rolRepository.Actualizar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Eliminar(EstadoEliminarRequest param)
        {
            var parammapper = _mapper.Map<EstadoEntity>(param);
            var responsemapper = await _rolRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<List<EstadoListarResponse>>> Listar()
        {
            var result = await this._rolRepository.Listar();
            var responsemapper = _mapper.Map<IEnumerable<EstadoListarResponse>>(result);
            var response = new HttpResponseResult<List<EstadoListarResponse>>() { Data = responsemapper.ToList<EstadoListarResponse>() };
            return response;
        }

        public async Task<HttpResponseResult<EstadoListarByIdResponse>> ListarById(int IdEstado)
        {
            var result = await this._rolRepository.ListarById(IdEstado);
            var responsemapper = _mapper.Map<EstadoListarByIdResponse>(result);
            var response = new HttpResponseResult<EstadoListarByIdResponse>() { Data = responsemapper };
            return response;
        }
    }
}
