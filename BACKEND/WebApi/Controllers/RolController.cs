using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Response.Rol;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RolController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly IRolService _rolService;
        public RolController(
              ILogger<RolController> logger
            , IRolService rolService)
        {
            this._rolService = rolService;
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
        [ProducesResponseType(typeof(RolListarDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Registrar([FromBody] RolRegistrar query)
        {
            return Ok(await _rolService.Registrar(query));
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
        [ProducesResponseType(typeof(RolListarDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Actualizar([FromBody] RolActualizar query)
        {
            return Ok(await _rolService.Actualizar(query));
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
        [HttpDelete("Eliminar")]
        [ProducesResponseType(typeof(RolListarDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Eliminar([FromBody] RolEliminar query)
        {
            return Ok(await _rolService.Eliminar(query));
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
        [ProducesResponseType(typeof(RolListarDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _rolService.Listar());
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
        ///         IdRol :1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet("ListarById")]
        [ProducesResponseType(typeof(RolListarDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ListarById(int IdRol)
        {
            return Ok(await _rolService.ListarById(IdRol));
        }
    }
}
