using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using ApplicationCore.Services;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Orden;
using Domain.DTO.Response.Orden;
using Moq;
using WebApixUnitTest.Mocks;

namespace WebApixUnitTest.ApplicationCore
{
    public class OrdenServiceShould
    {
        [Fact]
        public void GetRegistrar()
        {
            var _ordenService = new Mock<IOrdenService>();

            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _mockMapper = new Mock<IMapper>();

            var _ordenRegistrarRequest = _mock.GetMockOrdenRegistrarRequest();

            var listaresultado = new HttpResponseResult<int>() { Data = 1 };

            _ordenService.Setup(a => a.Registrar(_ordenRegistrarRequest)).Returns(Task.FromResult(listaresultado));

            var _service = new OrdenService(_ordenRepository.Object, _mockMapper.Object);

            var _res = _service.Registrar(_ordenRegistrarRequest).Result;

            Assert.True(_res.Success);
        }

        [Fact]
        public void GetActualizar()
        {
            var _ordenService = new Mock<IOrdenService>();

            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _mockMapper = new Mock<IMapper>();

            var _ordenRequest = _mock.GetMockOrdenActualizarRequest();

            var listaresultado = new HttpResponseResult<int>() { Data = 1 };

            _ordenService.Setup(a => a.Actualizar(_ordenRequest)).Returns(Task.FromResult(listaresultado));

            var _service = new OrdenService(_ordenRepository.Object, _mockMapper.Object);

            var _res = _service.Actualizar(_ordenRequest).Result;

            Assert.True(_res.Success);
        }

        [Fact]
        public void GetListar()
        {
            var _ordenService = new Mock<IOrdenService>();

            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _mockMapper = new Mock<IMapper>();

            var _ordenRequest = _mock.GetMockOrdenListarRequest();

            var listaresultado = new HttpResponseResult<List<OrdenListarResponse>> { Data = new List<OrdenListarResponse>() };

            _ordenService.Setup(a => a.Listar(_ordenRequest)).Returns(Task.FromResult(listaresultado));

            var _service = new OrdenService(_ordenRepository.Object, _mockMapper.Object);

            var _res = _service.Listar(_ordenRequest).Result;

            Assert.True(_res.Success);
        }

        [Theory]
        [InlineData(1)]
        public void GetListarById(int IdOrden)
        {
            var _ordenService = new Mock<IOrdenService>();

            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mockMapper = new Mock<IMapper>();

            var listaresultado = new HttpResponseResult<OrdenListarByIdResponse> { Data = new OrdenListarByIdResponse() };

            _ordenService.Setup(a => a.ListarById(IdOrden)).Returns(Task.FromResult(listaresultado));

            var _service = new OrdenService(_ordenRepository.Object, _mockMapper.Object);

            var _res = _service.ListarById(IdOrden).Result;

            Assert.True(_res.Success);
        }


        [Theory]
        [InlineData(1, 1)]
        public void GetEliminar(int IdOrden, int IdEstado)
        {
            var _ordenService = new Mock<IOrdenService>();

            var _ordenRepository = new Mock<IOrdenRepository>();

            //var _mock = new OrdenMock();

            var _mockMapper = new Mock<IMapper>();

            //var _ordenRequest = _mock.GetMockOrdenEliminarRequest();
            var _ordenRequest = new OrdenEliminarRequest { IdOrden = IdOrden, IdEstado = IdEstado };

            var listaresultado = new HttpResponseResult<int>() { Data = 1 };

            _ordenService.Setup(a => a.Eliminar(_ordenRequest)).Returns(Task.FromResult(listaresultado));

            var _service = new OrdenService(_ordenRepository.Object, _mockMapper.Object);

            var _res = _service.Eliminar(_ordenRequest).Result;

            Assert.True(_res.Success);
        }

    }
}
