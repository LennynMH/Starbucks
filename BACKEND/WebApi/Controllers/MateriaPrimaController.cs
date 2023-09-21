using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Request.MateriaPrima;
using Domain.DTO.Response.MateriaPrima;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MateriaPrimaController : BaseAutenticateController
    {
        private readonly ILogger<MateriaPrimaController> _logger;
        private readonly IMateriaPrimaService _materiaPrimaService;
        public MateriaPrimaController(
              ILogger<MateriaPrimaController> logger
            , IMateriaPrimaService materiaPrimaService)
        {
            this._materiaPrimaService = materiaPrimaService;
            this._logger = logger;
        }


        /// <summary>
        /// Crear Método que obtiene materia prima
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar materia prima</returns>
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
        [ProducesResponseType(typeof(MateriaPrimaListarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _materiaPrimaService.Listar());
        }

        /// <summary>
        /// Crear Método que eliminar materia prima
        /// </summary>
        /// <param name="query"></param>
        /// <returns>eliminar materia prima</returns>
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
        [HttpDelete("Eliminar/{IdMateriaPrima:int}")]
        [ProducesResponseType(typeof(MateriaPrimaEliminarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Eliminar(int IdMateriaPrima)
        {
            return Ok(await _materiaPrimaService.Eliminar(IdMateriaPrima));
        }
    }
}
