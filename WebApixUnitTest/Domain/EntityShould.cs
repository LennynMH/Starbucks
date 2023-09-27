using Domain.Entities;

namespace WebApixUnitTest.Domain
{
    public class EntityShould
    {
        [Fact]
        public void ValidateOrdenError()
        {
            var model = new OrdenEntity();
            var results = TestHelper.Validate(model);
            Assert.True(results.Count >= 0);
        }

        [Fact]
        public void ValidateOrdenOk()
        {
            var model = new OrdenEntity
            {
                IdOrden = 1,
                Empleado = new UsuarioEntity { IdUsuario = 1 },
                Usuario = new UsuarioEntity { IdUsuario = 2} ,
                Estado = new EstadoEntity { IdEstado = 1,},
                FechaCreacion = DateTime.Now,
                NumeroOrden = "",
                TiempoOrden = 10,
            };
            var results = TestHelper.Validate(model);
            Assert.True(results.Count == 0);
        }

    }
}
