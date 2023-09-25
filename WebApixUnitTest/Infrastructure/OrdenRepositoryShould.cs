using ApplicationCore.Interface.IRepositories;
using Infrastructure.Repositories;
using Moq;
using WebApixUnitTest.Mocks;

namespace WebApixUnitTest.Infrastructure
{
    public class OrdenRepositoryShould
    {
        [Fact]
        public void GetRegistro()
        {
            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _ordenEntity = _mock.GetMockOrdenEntity();

            var _ordenItemEntity = _mock.GetOrdenItemRegistrar();

            var listaresultado = 1;

            _ordenRepository.Setup(a => a.Registrar(_ordenEntity, _ordenItemEntity)).Returns(Task.FromResult(listaresultado));

            var configuration = ConfigurationHelper.Configuration();

            var _service = new OrdenRepository(configuration);

            var _res = _service.Registrar(_ordenEntity, _ordenItemEntity).Result;

            //Assert.NotNull(_res);
            Assert.True(_res > 0, "Se esperaba que realCount fuera mayor que 0");
        }

    }
}
