using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Rol;
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

        public async Task<HttpResponseResult<int>> Registrar(RolRegistrarRequest param)
        {
            var parammapper = _mapper.Map<RolEntity>(param);
            var responsemapper = await _rolRepository.Registrar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Actualizar(RolActualizarRequest param)
        {
            var parammapper = _mapper.Map<RolEntity>(param);
            var responsemapper = await _rolRepository.Actualizar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Eliminar(int IdRol)
        {
            var param = new RolEliminarRequest { IdRol = IdRol };
            var parammapper = _mapper.Map<RolEntity>(param);
            var responsemapper = await _rolRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<List<RolListarResponse>>> Listar()
        {
            var result = await this._rolRepository.Listar();
            var responsemapper = _mapper.Map<IEnumerable<RolListarResponse>>(result);
            var response = new HttpResponseResult<List<RolListarResponse>>() { Data = responsemapper.ToList<RolListarResponse>() };
            return response;
        }

        public async Task<HttpResponseResult<RolListarByIdResponse>> ListarById(int IdRol)
        {
            var result = await this._rolRepository.ListarById(IdRol);
            var responsemapper = _mapper.Map<RolListarByIdResponse>(result);
            var response = new HttpResponseResult<RolListarByIdResponse>() { Data = responsemapper };
            return response;
        }
    }
}
