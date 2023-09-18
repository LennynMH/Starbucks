using ApplicationCore.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
