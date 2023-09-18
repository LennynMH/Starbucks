using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Response.Usuario;

namespace ApplicationCore.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(
           IUsuarioRepository usuarioRepository
           , IMapper mapper)
        {
            this._usuarioRepository = usuarioRepository;
            this._mapper = mapper;
        }

        public async Task<HttpResponseResult<UsuarioListarByCodigoResponse>> ListarByCodigo(string? Codigo)
        {
            var result = await this._usuarioRepository.ListarByCodigo(Codigo);
            var responsemapper = _mapper.Map<UsuarioListarByCodigoResponse>(result);
            var response = new HttpResponseResult<UsuarioListarByCodigoResponse>() { Data = responsemapper };
            return response;
        }
    }
}
