using Domain.DTO.Request.Orden;
using Domain.DTO.Request.OrdenItem;
using Domain.Entities;

namespace WebApixUnitTest.Mocks
{
    public class OrdenMock
    {
        public OrdenEntity GetMockOrdenEntity()
        {
            OrdenItemEntity ordenItem = new OrdenItemEntity
            {
                IdOrdenItem = 1,
                Item = new ItemEntity { IdItem = 1 },
                Cantidad = 1,
                Precio = 1,
                TiempoItem = 1,
            };

            OrdenItemEntity ordenItem2 = new OrdenItemEntity
            {
                IdOrdenItem = 1,
                Item = new ItemEntity { IdItem = 2 },
                Cantidad = 2,
                Precio = 2,
                TiempoItem = 2,
            };

            List<OrdenItemEntity> listaOrdenItem = new List<OrdenItemEntity>();
            listaOrdenItem.Add(ordenItem);
            listaOrdenItem.Add(ordenItem2);

            var cliente = new OrdenEntity()
            {
                IdOrden = 1,
                Empleado = new UsuarioEntity { IdUsuario = 1 },
                Usuario = new UsuarioEntity { IdUsuario = 2 },
                Estado = new EstadoEntity { IdEstado = 1, },
                FechaCreacion = DateTime.Now,
                NumeroOrden = "",
                TiempoOrden = 10,
                //OrdenItem = listaOrdenItem
            };

            return cliente;
        }

        public List<OrdenItemRegistrarRequest> GetOrdenItemRegistrar()
        {
            OrdenItemRegistrarRequest ordenItem = new OrdenItemRegistrarRequest
            {
                IdOrdenItem = 1,
                IdItem = 1 ,
                Cantidad = 1,
                Precio = 1,
                TiempoItem = 1,
            };

            OrdenItemRegistrarRequest ordenItem2 = new OrdenItemRegistrarRequest
            {
                IdOrdenItem = 1,
                IdItem = 2 ,
                Cantidad = 2,
                Precio = 2,
                TiempoItem = 2,
            };

            List<OrdenItemRegistrarRequest> listaOrdenItem = new List<OrdenItemRegistrarRequest>();
            listaOrdenItem.Add(ordenItem);
            listaOrdenItem.Add(ordenItem2);

            return listaOrdenItem;
        }




        public OrdenRegistrarRequest GetMockOrdenRegistrarRequest()
        {
            OrdenItemEntity ordenItem = new OrdenItemEntity
            {
                IdOrdenItem = 1,
                Item = new ItemEntity { IdItem = 1 },
                Cantidad = 1,
                Precio = 1,
                TiempoItem = 1,
            };

            OrdenItemEntity ordenItem2 = new OrdenItemEntity
            {
                IdOrdenItem = 1,
                Item = new ItemEntity { IdItem = 2 },
                Cantidad = 2,
                Precio = 2,
                TiempoItem = 2,
            };

            List<OrdenItemEntity> listaOrdenItem = new List<OrdenItemEntity>();
            listaOrdenItem.Add(ordenItem);
            listaOrdenItem.Add(ordenItem2);

            var cliente = new OrdenRegistrarRequest()
            {
                IdOrden = 1,
                Empleado = new UsuarioEntity { IdUsuario = 1 },
                Usuario = new UsuarioEntity { IdUsuario = 2 },
                Estado = new EstadoEntity { IdEstado = 1, },
                FechaCreacion = DateTime.Now,
                NumeroOrden = "",
                TiempoOrden = 10,
                ListOrdenItem = listaOrdenItem
            };

            return cliente;
        }
    }
}
