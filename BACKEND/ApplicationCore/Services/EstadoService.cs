using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
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

        public async Task<HttpResponseResult<int>> Registrar(EstadoRegistrar param)
        {
            var parammapper = _mapper.Map<EstadoEntity>(param);
            var responsemapper = await _rolRepository.Registrar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Actualizar(EstadoActualizar param)
        {
            var parammapper = _mapper.Map<EstadoEntity>(param);
            var responsemapper = await _rolRepository.Actualizar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Eliminar(EstadoEliminar param)
        {
            var parammapper = _mapper.Map<EstadoEntity>(param);
            var responsemapper = await _rolRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<List<EstadoListarDto>>> Listar()
        {
            var result = await this._rolRepository.Listar();
            var responsemapper = _mapper.Map<IEnumerable<EstadoListarDto>>(result);
            var response = new HttpResponseResult<List<EstadoListarDto>>() { Data = responsemapper.ToList<EstadoListarDto>() };
            return response;
        }

        public async Task<HttpResponseResult<EstadoListarByIdDto>> ListarById(int IdEstado)
        {
            var result = await this._rolRepository.ListarById(IdEstado);
            var responsemapper = _mapper.Map<EstadoListarByIdDto>(result);
            var response = new HttpResponseResult<EstadoListarByIdDto>() { Data = responsemapper };
            return response;
        }
    }
}
