using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using ApplicationCore.Services;
using AutoMapper;
using Domain.Core;
using Moq;
using WebApixUnitTest.Mocks;

namespace WebApixUnitTest.ApplicationCore
{
    public class OrdenServiceShould
    {
        [Fact]
        public void GetRegistro()
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

            //Assert.NotNull(_res.Success);
            Assert.True(_res.Success);
        }
    }
}
