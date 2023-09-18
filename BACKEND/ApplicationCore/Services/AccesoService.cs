using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Acceso;
using Domain.DTO.Response.Acceso;
using Domain.DTO.Response.Usuario;
using Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApplicationCore.Services
{
    public class AccesoService : IAccesoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IContraseniaService _contraseniaService;
        private readonly AuthenticationOptions _authenticationOptions;
        private readonly IAccesoRepository _accesoRepository;
        private readonly IMapper _mapper;
        public AccesoService(
           IAccesoRepository accesoRepository
            , IUsuarioService usuarioService
            , IContraseniaService contraseniaService
            , IOptions<AuthenticationOptions> authenticationOptions
           , IMapper mapper)
        {
            this._usuarioService = usuarioService;
            this._contraseniaService = contraseniaService;
            this._authenticationOptions = authenticationOptions.Value;
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

        public async Task<HttpResponseResult<AccesoValidaUsuarioResponse>> ValidaAccesoUsuario(AccesoValidaUsuarioResquest query)
        {
            var validation = await IsValidUser(query);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                validation.Item2.Contrasena = string.Empty;
                return new HttpResponseResult<AccesoValidaUsuarioResponse>() { Data = new AccesoValidaUsuarioResponse { Usuario = validation.Item2, Token = token } };
            }
            else
            {
                return new HttpResponseResult<AccesoValidaUsuarioResponse>() { Success = false, Data = null };
            }
        }

        private async Task<(bool, UsuarioListarByCodigoResponse?)> IsValidUser(AccesoValidaUsuarioResquest login)
        {
            var userData = await this._usuarioService.ListarByCodigo(login.Codigo);
            var user = userData.Data;
            if (user == null) return (false, null);
            var isValid = this._contraseniaService.Check(user.Contrasena, login.Contrasena);
            return (isValid, user);
        }

        private string GenerateToken(UsuarioListarByCodigoResponse usuario)
        {
            /*
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var payload = new JwtSecurityToken(_authenticationOptions.Issuer,
                                            _authenticationOptions.Audience,
                                            claims: new List<Claim>
                                            {
                                                new Claim(ClaimTypes.Name, usuario.Codigo ?? "") ,
                                                new Claim("Usuario", JsonConvert.SerializeObject(usuario))
                                            },
                                            notBefore: DateTime.UtcNow,
                                            expires: DateTime.UtcNow.AddMinutes(_authenticationOptions.ExpiryTime),
                                            signingCredentials: signingCredentials);

            string token = new JwtSecurityTokenHandler().WriteToken(payload);
            return token;
           */
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var claims = new[]
            {
                    new Claim(ClaimTypes.Name, usuario.Codigo ?? "") ,
                    new Claim("Usuario", JsonConvert.SerializeObject(usuario))
                };
            var payload = new JwtPayload
            (
                _authenticationOptions.Issuer,
            _authenticationOptions.Audience,
            claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(_authenticationOptions.ExpiryTime)
            );
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
