using Domain.DTO.Request.Orden;
using Domain.DTO.Request.OrdenItem;
using Domain.Entities;

namespace WebApixUnitTest.Mocks
{
    public class OrdenMock
    {
        public OrdenEntity GetMockOrdenRegistraEntity()
        {
            List<OrdenItemEntity> listaOrdenItem = new List<OrdenItemEntity> {
                new OrdenItemEntity
                {
                    IdOrdenItem = 0,
                    Item = new ItemEntity { IdItem = 1 },
                    Cantidad = 1,
                    Precio = 1,
                    TiempoItem = 1,
                },new OrdenItemEntity
                {
                    IdOrdenItem = 0,
                    Item = new ItemEntity { IdItem = 2 },
                    Cantidad = 2,
                    Precio = 2,
                    TiempoItem = 2,
                }
            };

            var cliente = new OrdenEntity
            {
                IdOrden = 0,
                Empleado = new UsuarioEntity { IdUsuario = 1 },
                Usuario = new UsuarioEntity { IdUsuario = 2 },
                Estado = new EstadoEntity { IdEstado = 1, },
                FechaCreacion = DateTime.Now,
                NumeroOrden = "",
                TiempoOrden = 10,
                //OrdenItem = listaOrdenItem,
            };

            return cliente;
        }
        public List<OrdenItemRegistrarRequest> GetMockOrdenItemRegistraEntity()
        {
            List<OrdenItemRegistrarRequest> listaOrdenItem = new List<OrdenItemRegistrarRequest> {
                new OrdenItemRegistrarRequest
                {
                    IdOrdenItem = 0,
                    IdItem = 1,
                    Cantidad = 1,
                    Precio = 1,
                    TiempoItem = 1,
                },
                  new OrdenItemRegistrarRequest
                {
                    IdOrdenItem = 0,
                    IdItem = 2,
                    Cantidad = 2,
                    Precio = 2,
                    TiempoItem = 2,
                }
            };

            return listaOrdenItem;
        }

        public OrdenEntity GetMockOrdenActualizaEntity()
        {
            List<OrdenItemEntity> listaOrdenItem = new List<OrdenItemEntity> {
                new OrdenItemEntity
                {
                    IdOrdenItem = 1,
                    Orden = new OrdenEntity{ IdOrden = 1},
                    Item = new ItemEntity { IdItem = 1 },
                    Cantidad = 1,
                    Precio = 1,
                    TiempoItem = 1,
                },new OrdenItemEntity
                {
                    IdOrdenItem = 2,
                    Orden = new OrdenEntity{ IdOrden = 1},
                    Item = new ItemEntity { IdItem = 2 },
                    Cantidad = 2,
                    Precio = 2,
                    TiempoItem = 2,
                }
            };

            var cliente = new OrdenEntity
            {
                IdOrden = 1,
                Empleado = new UsuarioEntity { IdUsuario = 1 },
                Usuario = new UsuarioEntity { IdUsuario = 2 },
                Estado = new EstadoEntity { IdEstado = 1, },
                FechaCreacion = DateTime.Now,
                NumeroOrden = "",
                TiempoOrden = 10,
            };

            return cliente;
        }

        public OrdenEntity GetMockOrdenEiminarEntity()
        {
            var cliente = new OrdenEntity
            {
                IdOrden = 1,
                Estado = new EstadoEntity { IdEstado = 1, },
                FechaCreacion = DateTime.Now,
            };

            return cliente;
        }
        public OrdenEntity GetMockOrdenListarEntity()
        {
            var entity = new OrdenEntity
            {
                Empleado = new UsuarioEntity { IdUsuario = 0 },
                Usuario = new UsuarioEntity { IdUsuario = 0 },
                Estado = new EstadoEntity { IdEstado = 1, },
            };

            return entity;
        }

        public List<OrdenItemRegistrarRequest> GetMockOrdenItemActualizaEntity()
        {
            List<OrdenItemRegistrarRequest> listaOrdenItem = new List<OrdenItemRegistrarRequest> {
                new OrdenItemRegistrarRequest
                {
                    IdOrdenItem = 1,
                    IdItem = 1,
                    Cantidad = 1,
                    Precio = 1,
                    TiempoItem = 1,
                },
                  new OrdenItemRegistrarRequest
                {
                    IdOrdenItem = 2,
                    IdItem = 2,
                    Cantidad = 2,
                    Precio = 2,
                    TiempoItem = 2,
                }
            };

            return listaOrdenItem;
        }


        public OrdenRegistrarRequest GetMockOrdenRegistrarRequest()
        {
            List<OrdenItemEntity> listaOrdenItem = new List<OrdenItemEntity> {
                new OrdenItemEntity
                {
                    IdOrdenItem = 0,
                    Item = new ItemEntity { IdItem = 1 },
                    Cantidad = 1,
                    Precio = 1,
                    TiempoItem = 1,
                },
                new OrdenItemEntity
                {
                    IdOrdenItem = 0,
                    Item = new ItemEntity { IdItem = 2 },
                    Cantidad = 2,
                    Precio = 2,
                    TiempoItem = 2,
                }
            };

            var cliente = new OrdenRegistrarRequest()
            {
                IdOrden = 0,
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

        public OrdenRegistrarRequest GetMockOrdenActualizarRequest()
        {
            List<OrdenItemEntity> listaOrdenItem = new List<OrdenItemEntity> {
                new OrdenItemEntity
                {
                    IdOrdenItem = 1,
                    Item = new ItemEntity { IdItem = 1 },
                    Cantidad = 1,
                    Precio = 1,
                    TiempoItem = 10,
                },
                new OrdenItemEntity
                {
                    IdOrdenItem = 2,
                    Item = new ItemEntity { IdItem = 2 },
                    Cantidad = 2,
                    Precio = 2,
                    TiempoItem = 10,
                }
            };

            var cliente = new OrdenRegistrarRequest()
            {
                IdOrden = 1,
                Empleado = new UsuarioEntity { IdUsuario = 1 },
                Usuario = new UsuarioEntity { IdUsuario = 2 },
                Estado = new EstadoEntity { IdEstado = 1, },
                FechaCreacion = DateTime.Now,
                NumeroOrden = "",
                TiempoOrden = 20,
                ListOrdenItem = listaOrdenItem
            };

            return cliente;
        }

        public OrdenListarRequest GetMockOrdenListarRequest()
        {
            var cliente = new OrdenListarRequest()
            {
                Empleado = new UsuarioEntity { IdUsuario = 1 },
                Usuario = new UsuarioEntity { IdUsuario = 2 },
            };
            return cliente;
        }
        public OrdenEliminarRequest GetMockOrdenEliminarRequest()
        {
            var cliente = new OrdenEliminarRequest()
            {
                IdOrden = 1,
                IdEstado = 1,

            };
            return cliente;
        }

    }
}
