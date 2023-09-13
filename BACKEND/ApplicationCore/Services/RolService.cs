using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Response.Rol;
using Domain.Entities;

namespace ApplicationCore.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;
        public RolService(
           IRolRepository rolRepository
           , IMapper mapper)
        {
            this._rolRepository = rolRepository;
            this._mapper = mapper;
        }

        public async Task<HttpResponseResult<int>> Registrar(RolRegistrar param)
        {
            var parammapper = _mapper.Map<RolEntity>(param);
            var responsemapper = await _rolRepository.Registrar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Actualizar(RolActualizar param)
        {
            var parammapper = _mapper.Map<RolEntity>(param);
            var responsemapper = await _rolRepository.Actualizar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Eliminar(RolEliminar param)
        {
            var parammapper = _mapper.Map<RolEntity>(param);
            var responsemapper = await _rolRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<List<RolListarDto>>> Listar()
        {
            var result = await this._rolRepository.Listar();
            var responsemapper = _mapper.Map<IEnumerable<RolListarDto>>(result);
            var response = new HttpResponseResult<List<RolListarDto>>() { Data = responsemapper.ToList<RolListarDto>() };
            return response;
        }

        public async Task<HttpResponseResult<RolListarByIdDto>> ListarById(int IdRol)
        {
            var result = await this._rolRepository.ListarById(IdRol);
            var responsemapper = _mapper.Map<RolListarByIdDto>(result);
            var response = new HttpResponseResult<RolListarByIdDto>() { Data = responsemapper };
            return response;
        }
    }
}
