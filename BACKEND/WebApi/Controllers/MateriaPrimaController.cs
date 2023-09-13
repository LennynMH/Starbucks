using ApplicationCore.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaController : ControllerBase
    {
        private readonly ILogger<MateriaPrimaController> _logger;
        private readonly IMateriaPrimaService _materiaPrimaService;
        public MateriaPrimaController(
              ILogger<MateriaPrimaController> logger
            , IMateriaPrimaService materiaPrimaService)
        {
            this._materiaPrimaService = materiaPrimaService;
            this._logger = logger;
        }




    }
}
