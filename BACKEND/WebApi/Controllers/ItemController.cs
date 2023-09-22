using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Request.Item;
using Domain.DTO.Response.Item;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseAutenticateController
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;
        public ItemController(
              ILogger<ItemController> logger
            , IItemService itemService)
        {
            this._itemService = itemService;
            this._logger = logger;
        }

        /// <summary>
        /// Crear Método que registra Item
        /// </summary>
        /// <param name="query"></param>
        /// <returns>registrar Item</returns>
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
        [ProducesResponseType(typeof(ItemRegistrarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Registrar([FromBody] ItemRegistrarRequest query)
        {
            return Ok(await _itemService.Registrar(query));
        }

        /// <summary>
        /// Crear Método que obtiene items
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar items</returns>
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
        [ProducesResponseType(typeof(ItemListarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _itemService.Listar());
        }


        /// <summary>
        /// Crear Método que eliminar items
        /// </summary>
        /// <param name="query"></param>
        /// <returns>eliminar items</returns>
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
        [HttpDelete("Eliminar/{IdItem:int}")]
        [ProducesResponseType(typeof(ItemEliminarRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Eliminar(int IdItem)
        {
            return Ok(await _itemService.Eliminar(IdItem));
        }


        /// <summary>
        /// Crear Método que obtiene item x id
        /// </summary>
        /// <param name="item"></param>
        /// <returns>listar item x id</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /ListarById
        ///     {
        ///         IdItem :1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet("ListarById")]
        [ProducesResponseType(typeof(ItemListarByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponseResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ListarById(int IdItem)
        {
            return Ok(await _itemService.ListarById(IdItem));
        }
    }
}
