using ApplicationCore.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly ILogger<AccesoController> _logger;
        private readonly IAccesoService _accesoService;
        public AccesoController(
              ILogger<AccesoController> logger
            , IAccesoService accesoService)
        {
            this._accesoService = accesoService;
            this._logger = logger;
        }



    }
}
