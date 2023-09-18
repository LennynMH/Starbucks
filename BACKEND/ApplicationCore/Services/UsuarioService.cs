using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Usuario;
using Domain.DTO.Response.Usuario;
using Domain.Entities;

namespace ApplicationCore.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IContraseniaService _contraseniaService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(
           IUsuarioRepository usuarioRepository
           , IContraseniaService contraseniaService
           , IMapper mapper)
        {
            this._usuarioRepository = usuarioRepository;
            this._contraseniaService = contraseniaService;
            this._mapper = mapper;
        }

        public async Task<HttpResponseResult<int>> Registrar(UsuarioRegistrarRequest param)
        {
            var parammapper = _mapper.Map<UsuarioEntity>(param);
            parammapper.Contrasena = this._contraseniaService.Hash(parammapper.Codigo);
            var responsemapper = await _usuarioRepository.Registrar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Actualizar(UsuarioActualizarRequest param)
        {
            var parammapper = _mapper.Map<UsuarioEntity>(param);
            var responsemapper = await _usuarioRepository.Actualizar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<int>> Eliminar(int IdUsuario)
        {
            var param = new UsuarioEliminarRequest { IdUsuario = IdUsuario };
            var parammapper = _mapper.Map<UsuarioEntity>(param);
            var responsemapper = await _usuarioRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }

        public async Task<HttpResponseResult<List<UsuarioListarResponse>>> Listar(UsuarioRegistrarRequest param)
        {
            var requestmapper = _mapper.Map<UsuarioEntity>(param);
            var result = await this._usuarioRepository.Listar(requestmapper);
            var responsemapper = _mapper.Map<IEnumerable<UsuarioListarResponse>>(result);
            var response = new HttpResponseResult<List<UsuarioListarResponse>>() { Data = responsemapper.ToList<UsuarioListarResponse>() };
            return response;
        }

        public async Task<HttpResponseResult<UsuarioListarByIdResponse>> ListarById(int IdUsuario)
        {
            var result = await this._usuarioRepository.ListarById(IdUsuario);
            var responsemapper = _mapper.Map<UsuarioListarByIdResponse>(result);
            var response = new HttpResponseResult<UsuarioListarByIdResponse>() { Data = responsemapper };
            return response;
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
