using ApplicationCore.Interface.IServices;
using Domain.Core;
using Domain.DTO.Response.Orden;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;
using WebApixUnitTest.Mocks;

namespace WebApixUnitTest.Controller
{
    public class OrdenControllerShould
    {
        [Fact]
        public void GetRegistrar()
        {
            var _logger = new Mock<ILogger<OrdenController>>();

            var _ordenService = new Mock<IOrdenService>();

            var _mock = new OrdenMock();

            var _ordenRequest = _mock.GetMockOrdenRegistrarRequest();

            var controller = new OrdenController(_logger.Object, _ordenService.Object);

            var listaresultado = new HttpResponseResult<int>() { Data = 1 };

            _ordenService.Setup(a => a.Registrar(_ordenRequest)).Returns(Task.FromResult(listaresultado));

            var _res = controller.Registrar(_ordenRequest).Result;

            Assert.NotNull(_res);
            Assert.IsType<OkObjectResult?>(_res);
        }

        [Fact]
        public void GetActualizar()
        {
            var _logger = new Mock<ILogger<OrdenController>>();

            var _ordenService = new Mock<IOrdenService>();

            var _mock = new OrdenMock();

            var _ordenRequest = _mock.GetMockOrdenActualizarRequest();

            var controller = new OrdenController(_logger.Object, _ordenService.Object);

            var listaresultado = new HttpResponseResult<int>() { Data = 1 };

            _ordenService.Setup(a => a.Actualizar(_ordenRequest)).Returns(Task.FromResult(listaresultado));

            var _res = controller.Actualizar(_ordenRequest).Result;

            Assert.NotNull(_res);
            Assert.IsType<OkObjectResult?>(_res);
        }

        [Fact]
        public void GetListar()
        {
            var _logger = new Mock<ILogger<OrdenController>>();

            var _ordenService = new Mock<IOrdenService>();

            var _mock = new OrdenMock();

            var _ordenRequest = _mock.GetMockOrdenListarRequest();

            var controller = new OrdenController(_logger.Object, _ordenService.Object);

            var listaresultado = new HttpResponseResult<List<OrdenListarResponse>> { Data = new List<OrdenListarResponse>() };

            _ordenService.Setup(a => a.Listar(_ordenRequest)).Returns(Task.FromResult(listaresultado));

            var _res = controller.Listar(_ordenRequest).Result;

            Assert.NotNull(_res);
            Assert.IsType<OkObjectResult?>(_res);
        }

        [Theory]
        [InlineData(1)]
        public void GetListarById(int IdOrden)
        {
            var _logger = new Mock<ILogger<OrdenController>>();

            var _ordenService = new Mock<IOrdenService>();

            var controller = new OrdenController(_logger.Object, _ordenService.Object);

            var listaresultado = new HttpResponseResult<OrdenListarByIdResponse> { Data = new OrdenListarByIdResponse() };

            _ordenService.Setup(a => a.ListarById(IdOrden)).Returns(Task.FromResult(listaresultado));

            var _res = controller.ListarById(IdOrden).Result;

            Assert.NotNull(_res);
            Assert.IsType<OkObjectResult?>(_res);
        }


        [Theory]
        [InlineData(1, 1)]
        public void GetEliminar(int IdOrden, int IdEstado)
        {
            var _logger = new Mock<ILogger<OrdenController>>();

            var _ordenService = new Mock<IOrdenService>();

            var _mock = new OrdenMock();

            var _ordenRequest = _mock.GetMockOrdenEliminarRequest();

            var controller = new OrdenController(_logger.Object, _ordenService.Object);

            var listaresultado = new HttpResponseResult<int>() { Data = 1 };

            _ordenService.Setup(a => a.Eliminar(_ordenRequest)).Returns(Task.FromResult(listaresultado));

            var _res = controller.Eliminar(IdOrden, IdEstado).Result;

            Assert.NotNull(_res);
            Assert.IsType<OkObjectResult?>(_res);
        }
    }
}
