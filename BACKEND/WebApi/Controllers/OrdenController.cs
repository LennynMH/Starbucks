using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Request.Orden;
using Domain.DTO.Response.Orden;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : BaseAutenticateController
    {
        private readonly ILogger<OrdenController> _logger;
        private readonly IOrdenService _ordenService;
        public OrdenController(
              ILogger<OrdenController> logger
            , IOrdenService ordenService)
        {
            this._ordenService = ordenService;
            this._logger = logger;
        }


        /// <summary>
        /// Crear Método que registra orden
        /// </summary>
        /// <param name="query"></param>
        /// <returns>registrar orden</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Registrar
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created orden</response>
        /// <response code="400">If the orden is null</response>
        [HttpPost("Registrar")]
        [ProducesResponseType(typeof(OrdenRegistrarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Registrar([FromBody] OrdenRegistrarRequest query)
        {
            return Ok(await _ordenService.Registrar(query));
        }

        /// <summary>
        /// Crear Método que actualizar orden
        /// </summary>
        /// <param name="query"></param>
        /// <returns>actualizar orden</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Actualizar
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created orden</response>
        /// <response code="400">If the orden is null</response>
        [HttpPut("Actualizar")]
        [ProducesResponseType(typeof(OrdenRegistrarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Actualizar([FromBody] OrdenRegistrarRequest query)
        {
            return Ok(await _ordenService.Actualizar(query));
        }

        /// <summary>
        /// Crear Método que obtiene orden
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar orden</returns>
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
        [ProducesResponseType(typeof(OrdenListarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Listar([FromBody] OrdenListarRequest query)
        {
            return Ok(await _ordenService.Listar(query));
        }


        /// <summary>
        /// Crear Método que obtiene orden x id
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar orden x id</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ListarById
        ///     {
        ///         Idorden :1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet("ListarById")]
        [ProducesResponseType(typeof(OrdenListarByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ListarById(int IdOrden)
        {
            return Ok(await _ordenService.ListarById(IdOrden));
        }


        /// <summary>
        /// Crear Método que eliminar orden
        /// </summary>
        /// <param name="query"></param>
        /// <returns>eliminar orden</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Eliminar
        ///     {
        ///     }
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpDelete("Eliminar/{IdOrden:int}/{IdEstado:int}")]
        [ProducesResponseType(typeof(OrdenEliminarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Eliminar(int IdOrden, int IdEstado)
        {
            var query = new OrdenEliminarRequest { IdOrden = IdOrden, IdEstado = IdEstado };
            return Ok(await _ordenService.Eliminar(query));
        }

    }
}
