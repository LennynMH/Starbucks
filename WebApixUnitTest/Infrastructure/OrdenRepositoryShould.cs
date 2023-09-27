using ApplicationCore.Interface.IRepositories;
using Domain.DTO.Response.Orden;
using Domain.Entities;
using Infrastructure.Repositories;
using Moq;
using WebApixUnitTest.Mocks;

namespace WebApixUnitTest.Infrastructure
{
    public class OrdenRepositoryShould
    {
        [Fact]
        public void GetRegistrar()
        {
            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _ordenEntity = _mock.GetMockOrdenRegistraEntity();

            var _ordenItemEntity = _mock.GetMockOrdenItemRegistraEntity();

            var listaresultado = 1;

            _ordenRepository.Setup(a => a.Registrar(_ordenEntity, _ordenItemEntity)).Returns(Task.FromResult(listaresultado));

            var configuration = ConfigurationHelper.Configuration();

            var _service = new OrdenRepository(configuration);

            var _res = _service.Registrar(_ordenEntity, _ordenItemEntity).Result;

            Assert.True(_res > 0, "Se esperaba que response fuera mayor que 0");
        }

        [Fact]
        public void GetActualizar()
        {
            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _ordenEntity = _mock.GetMockOrdenActualizaEntity();

            var _ordenItemEntity = _mock.GetMockOrdenItemActualizaEntity();

            var listaresultado = 1;

            _ordenRepository.Setup(a => a.Actualizar(_ordenEntity, _ordenItemEntity)).Returns(Task.FromResult(listaresultado));

            var configuration = ConfigurationHelper.Configuration();

            var _service = new OrdenRepository(configuration);

            var _res = _service.Actualizar(_ordenEntity, _ordenItemEntity).Result;

            Assert.True(_res > 0, "Se esperaba que response fuera mayor que 0");
        }


        [Fact]
        public void GetListar()
        {
            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _ordenEntity = _mock.GetMockOrdenListarEntity();

            var listaresultado = new List<OrdenEntity>();

            _ordenRepository.Setup(a => a.Listar(_ordenEntity)).Returns(Task.FromResult(listaresultado.AsEnumerable()));

            var configuration = ConfigurationHelper.Configuration();

            var _service = new OrdenRepository(configuration);

            var _res = _service.Listar(_ordenEntity).Result;

            Assert.NotNull(_res);
            Assert.True(_res.Count() > 0, "Se esperaba que response fuera mayor que 0");
        }

        [Theory]
        [InlineData(1)]
        public void GetListarById(int IdOrden)
        {
            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _ordenEntity = _mock.GetMockOrdenListarEntity();

            var listaresultado = new OrdenListarByIdResponse();

            _ordenRepository.Setup(a => a.ListarById(IdOrden)).Returns(Task.FromResult(listaresultado));

            var configuration = ConfigurationHelper.Configuration();

            var _service = new OrdenRepository(configuration);

            var _res = _service.ListarById(IdOrden).Result;

            Assert.NotNull(_res);
        }

        [Theory]
        [InlineData(5, 1, 1)]
        public void GetEliminar(int IdOrden, int IdEmpleado, int IdEstado)
        {
            var _ordenRepository = new Mock<IOrdenRepository>();

            var _mock = new OrdenMock();

            var _ordenEntity = new OrdenEntity
            {
                IdOrden = IdOrden,
                Empleado = new UsuarioEntity { IdUsuario = IdEmpleado },
                Estado = new EstadoEntity { IdEstado = IdEstado }
            };

            var listaresultado = 1;

            _ordenRepository.Setup(a => a.Eliminar(_ordenEntity)).Returns(Task.FromResult(listaresultado));

            var configuration = ConfigurationHelper.Configuration();

            var _service = new OrdenRepository(configuration);

            var _res = _service.Eliminar(_ordenEntity).Result;

            Assert.True(_res > 0, "Se esperaba que response fuera mayor que 0");
        }
    }
}
