using ApplicationCore.Interface.IServices;
using ApplicationCore.Services;
using Domain.Core;
using Domain.DTO.Request.Acceso;
using Domain.DTO.Request.Estado;
using Domain.DTO.Response.Acceso;
using Domain.DTO.Response.Estado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly ILogger<AccesoController> _logger;
        private readonly IAccesoService _accesoService;
        public AccesoController(
              ILogger<AccesoController> logger
            , IAccesoService accesoService)
        {
            this._accesoService = accesoService;
            this._logger = logger;
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
            return Ok(await _accesoService.ValidaAccesoUsuario(query));
        }
    }
}
