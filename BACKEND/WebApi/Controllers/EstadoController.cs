using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Request.Estado;
using Domain.DTO.Response.Estado;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EstadoController : BaseAutenticateController
    {
        private readonly ILogger<EstadoController> _logger;
        private readonly IEstadoService _estadoService;
        public EstadoController(
              ILogger<EstadoController> logger
            , IEstadoService estadoService)
        {
            this._estadoService = estadoService;
            this._logger = logger;
        }

        /// <summary>
        /// Crear Método que registra estado
        /// </summary>
        /// <param name="query"></param>
        /// <returns>registrar estado</returns>
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
        [ProducesResponseType(typeof(EstadoRegistrarResquest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Registrar([FromBody] EstadoRegistrarResquest query)
        {
            return Ok(await _estadoService.Registrar(query));
        }


        /// <summary>
        /// Crear Método que actualizar estado
        /// </summary>
        /// <param name="query"></param>
        /// <returns>actualizar estado</returns>
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
        [ProducesResponseType(typeof(EstadoActualizarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Actualizar([FromBody] EstadoActualizarRequest query)
        {
            return Ok(await _estadoService.Actualizar(query));
        }


        /// <summary>
        /// Crear Método que eliminar estado
        /// </summary>
        /// <param name="query"></param>
        /// <returns>eliminar estado</returns>
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
        [ProducesResponseType(typeof(EstadoEliminarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Eliminar([FromBody] EstadoEliminarRequest query)
        {
            return Ok(await _estadoService.Eliminar(query));
        }


        /// <summary>
        /// Crear Método que obtiene estado
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar estado</returns>
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
        [ProducesResponseType(typeof(EstadoListarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _estadoService.Listar());
        }


        /// <summary>
        /// Crear Método que obtiene estado x id
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar estado x id</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ListarById
        ///     {
        ///         IdEstado :1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet("ListarById")]
        [ProducesResponseType(typeof(EstadoListarByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ListarById(int IdEstado)
        {
            return Ok(await _estadoService.ListarById(IdEstado));
        }

    }
}
