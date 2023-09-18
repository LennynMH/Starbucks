using ApplicationCore.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseAutenticateController
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(
              ILogger<UsuarioController> logger
            , IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
            this._logger = logger;
        }

    }
}
