using ApplicationCore.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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



    }
}
