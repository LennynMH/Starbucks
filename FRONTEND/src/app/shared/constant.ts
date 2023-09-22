export const IncomeWebApi = {
    Login: "/api/Acceso/ValidaAccesoUsuario",
    RolRegistrar: "/api/Rol/Registrar",
    RolActualizar: "/api/Rol/Actualizar",
    RolListar: "/api/Rol/Listar",
    RolListarById: "/api/Rol/ListarById",
    RolEliminar: "/api/Rol/Eliminar",

    UsuarioRegistrar: "/api/Usuario/Registrar",
    UsuarioActualizar: "/api/Usuario/Actualizar",
    UsuarioListar: "/api/Usuario/Listar",
    UsuarioListarById: "/api/Usuario/ListarById",
    UsuarioEliminar: "/api/Usuario/Eliminar",

    ItemListar: "/api/Item/Listar",
    ItemEliminar: "/api/Item/Eliminar",
    ItemActualizar: "/api/Item/Actualizar",
    ItemRegistrar: "/api/Item/Registrar",
    ItemListarById: "/api/Item/ListarById",

    MateriaPrimaListar: "/api/MateriaPrima/Listar",
    MateriaPrimaEliminar: "/api/MateriaPrima/Eliminar",

    OrdenListar: "/api/Orden/Listar",
    OrdenEliminar: "/api/Orden/Eliminar",
    OrdenActualizar: "/api/Orden/Actualizar",
    OrdenRegistrar: "/api/Orden/Registrar",
    OrdenListarById: "/api/Orden/ListarById",
}

export const RolesWebApi = {
    Administrador: "1",
    Usuario: "2",
    Empleado: "3",
    Supervisor: "4",
}

export const MenuWebApi = {
    //El administrador tiene la capacidad de modificar y borrar usuarios y roles, 
    //como también subsanar errores generados durante la operación y parametrizar el sistema.
    Administrador: [
        {
            id: 1,
            text: 'Usuario',
            url: '/Home/Usuario',
        },
        {
            id: 2,
            text: 'Roles',
            url: '/Home/Roles',
        },
        {
            id: 3,
            text: 'Items',
            url: '/Home/Items',
        },
        {
            id: 4,
            text: 'Materia Prima',
            url: '/Home/MateriaPrima',
        },
        {
            id: 5,
            text: 'Ordenes',
            url: '/Home/Ordenes',
        },
        {
            id: 6,
            text: 'Actualizar Orden',
            url: '/Home/ActualizaOrden',
        },
        {
            id: 7,
            text: 'Facturas',
            url: '/Home/Facturas',
        },
    ],
    //El usuario solo puede realizar ordenes de los ítems disponibles en función de las materias primas disponibles.
    Usuario: [
        {
            id: 5,
            text: 'Ordenes',
            url: '/Home/Ordenes',
        },
    ],
    //El empleado toma la orden de los usuarios y la ejecutan. Una vez finalizada su ejecución, esta está lista para ser facturada
    Empleado: [
        {
            id: 5,
            text: 'Actualizar Orden',
            url: '/Home/ActualizaOrden',
        },
    ],
    //El supervisor tiene la capacidad de ver los trabajos que están haciendo los empleados y
    //la responsabilidad de facturar las ordenes finalizadas. También tiene la responsabilidad
    //de ajustar el stock de la materia prima disponible.
    Supervisor: [
        {
            id: 4,
            text: 'Materia Prima',
            url: '/Home/MateriaPrima',
        },
        {
            id: 3,
            text: 'Items',
            url: '/Home/Items',
        },
        {
            id: 5,
            text: 'Ordenes',
            url: '/Home/Ordenes',
        },
        {
            id: 7,
            text: 'Facturas',
            url: '/Home/Facturas',
        },
    ]
}


