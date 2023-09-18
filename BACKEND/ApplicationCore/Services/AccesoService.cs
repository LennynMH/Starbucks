using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Acceso;
using Domain.DTO.Response.Acceso;

namespace ApplicationCore.Services
{
    public class AccesoService : IAccesoService
    {
        private readonly IAccesoRepository _accesoRepository;
        private readonly IMapper _mapper;
        public AccesoService(
           IAccesoRepository accesoRepository
           , IMapper mapper)
        {
            this._accesoRepository = accesoRepository;
            this._mapper = mapper;
        }

        //public async Task<HttpResponseResult<AccesoValidaUsuarioResponse>> ValidaAccesoUsuario(AccesoValidaUsuarioResquest query)
        //{
        //    var result = await this._accesoRepository.ValidaAccesoUsuario(query.Codigo, query.Contrasena);
        //    var responsemapper = _mapper.Map<AccesoValidaUsuarioResponse>(result);
        //    var response = new HttpResponseResult<AccesoValidaUsuarioResponse>() { Data = responsemapper };
        //    return response;
        //}
    }
}
