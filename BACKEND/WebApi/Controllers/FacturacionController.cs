using ApplicationCore.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private readonly ILogger<FacturacionController> _logger;
        private readonly IFacturacionService _facturacionService;
        public FacturacionController(
              ILogger<FacturacionController> logger
            , IFacturacionService facturacionService)
        {
            this._facturacionService = facturacionService;
            this._logger = logger;
        }


    }
}
