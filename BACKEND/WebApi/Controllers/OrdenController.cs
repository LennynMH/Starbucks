﻿using ApplicationCore.Interface.IServices;
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
        public async Task<IActionResult> Listar()
        {
            return Ok(await _ordenService.Listar());
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
        //[HttpDelete("Eliminar/{IdItem:int}")]
        [HttpDelete("Eliminar")]
        [ProducesResponseType(typeof(OrdenEliminarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Eliminar([FromBody] OrdenEliminarRequest query)
        {
            return Ok(await _ordenService.Eliminar(query));
        }

    }
}
