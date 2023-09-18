using ApplicationCore.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
