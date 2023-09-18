using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAutenticateController : ControllerBase
    {
        protected BadRequestObjectResult badRequest(string errorMensaje)
        {
            return BadRequest(new { ErrorMensaje = errorMensaje });
        }
    }

}
