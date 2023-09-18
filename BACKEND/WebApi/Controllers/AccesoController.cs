using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Request.Acceso;
using Domain.DTO.Response.Acceso;
using Domain.DTO.Response.Usuario;
using Domain.Options;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly ILogger<AccesoController> _logger;
        private readonly IAccesoService _accesoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IContraseniaService _contraseniaService;
        private readonly AuthenticationOptions _authenticationOptions;

        public AccesoController(
              ILogger<AccesoController> logger
            , IAccesoService accesoService
            , IUsuarioService usuarioService
            , IContraseniaService contraseniaService
            , IOptions<AuthenticationOptions> authenticationOptions)
        {
            this._accesoService = accesoService;
            this._logger = logger;
            this._usuarioService = usuarioService;
            this._contraseniaService = contraseniaService;
            this._authenticationOptions = authenticationOptions.Value;
        }


        /// <summary>
        /// Crear Método que valida acceso por usuario
        /// </summary>
        /// <param name="item"></param>
        /// <returns>valida acceso por usuario</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ValidaAccesoUsuario
        ///     {
        ///         Codigo :"01010101",
        ///         Contrasena : "12345"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("ValidaAccesoUsuario")]
        [ProducesResponseType(typeof(AccesoValidaUsuarioResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ValidaAccesoUsuario([FromBody] AccesoValidaUsuarioResquest query)
        {

            HttpResponseResult<AccesoValidaUsuarioResponse> response;
            var validation = await IsValidUser(query);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                response = new HttpResponseResult<AccesoValidaUsuarioResponse>() { Data = new AccesoValidaUsuarioResponse { Usuario = validation.Item2, Token = token } };
            }
            else
            {
                response = new HttpResponseResult<AccesoValidaUsuarioResponse>() { Success = false, Data = null };
            }
            return Ok(response);
            //return Ok(await _accesoService.ValidaAccesoUsuario(query));
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
