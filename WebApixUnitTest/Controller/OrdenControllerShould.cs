using ApplicationCore.Interface.IServices;
using ApplicationCore.Services;
using AutoMapper;
using Domain.Core;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApixUnitTest.Mocks;

namespace WebApixUnitTest.Controller
{
    public class OrdenControllerShould
    {
        [Fact]
        public void GetRegistro()
        {
            var _logger = new Mock<ILogger<OrdenController>>();

            var _ordenService = new Mock<IOrdenService>();

            var _mock = new OrdenMock();

            var _ordenRegistrarRequest = _mock.GetMockOrdenRegistrarRequest();

            var controller = new OrdenController(_logger.Object, _ordenService.Object);

            var listaresultado = new HttpResponseResult<int>() { Data = 1 };

            _ordenService.Setup(a => a.Registrar(_ordenRegistrarRequest)).Returns(Task.FromResult(listaresultado));

            var _res = controller.Registrar(_ordenRegistrarRequest).Result;

            Assert.NotNull(_res);
        }

    }
}
