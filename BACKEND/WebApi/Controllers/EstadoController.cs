using ApplicationCore.Interface.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly ILogger<EstadoController> _logger;
        private readonly IEstadoService  _estadoService;
        public EstadoController(
              ILogger<EstadoController> logger
            , IEstadoService estadoService)
        {
            this._estadoService = estadoService;
            this._logger = logger;
        }

    }
}
