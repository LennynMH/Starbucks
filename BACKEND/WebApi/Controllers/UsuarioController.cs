using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Request.Usuario;
using Domain.DTO.Response.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseAutenticateController
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(
              ILogger<UsuarioController> logger
            , IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
            this._logger = logger;
        }

        /// <summary>
        /// Crear Método que registra rol
        /// </summary>
        /// <param name="query"></param>
        /// <returns>registrar rol</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Registrar
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("Registrar")]
        [ProducesResponseType(typeof(UsuarioRegistrarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistrarRequest query)
        {
            return Ok(await _usuarioService.Registrar(query));
        }


        /// <summary>
        /// Crear Método que actualizar rol
        /// </summary>
        /// <param name="query"></param>
        /// <returns>actualizar rol</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Actualizar
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPut("Actualizar")]
        [ProducesResponseType(typeof(UsuarioActualizarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioActualizarRequest query)
        {
            return Ok(await _usuarioService.Actualizar(query));
        }


        /// <summary>
        /// Crear Método que eliminar rol
        /// </summary>
        /// <param name="query"></param>
        /// <returns>eliminar rol</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Eliminar
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        //[HttpDelete("Eliminar")]
        [HttpDelete("Eliminar/{IdUsuario:int}")]
        [ProducesResponseType(typeof(UsuarioEliminarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Eliminar(int IdUsuario)
        {
            return Ok(await _usuarioService.Eliminar(IdUsuario));
        }


        /// <summary>
        /// Crear Método que obtiene rol
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar rol</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Listar
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("Listar")]
        [ProducesResponseType(typeof(UsuarioListarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Listar([FromBody] UsuarioRegistrarRequest query)
        {
            return Ok(await _usuarioService.Listar(query));
        }


        /// <summary>
        /// Crear Método que obtiene rol x id
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar rol x id</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ListarById
        ///     {
        ///         IdUsuario :1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet("ListarById")]
        [ProducesResponseType(typeof(UsuarioListarByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ListarById(int IdUsuario)
        {
            return Ok(await _usuarioService.ListarById(IdUsuario));
        }
    }
}
