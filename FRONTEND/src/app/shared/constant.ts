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
}

export const RolesWebApi = {
    Administrador: "1",
    Usuario: "2",
    Empleado: "3",
    Supervisor: "4",
}

export const MenuWebApi = {
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
            text: 'Facturas',
            url: '/Home/Facturas',
        },
    ],
    Usuario: [
        {
            id: 3,
            text: 'Items',
            url: '/Home/Items',
        },
    ],
    Empleado: [
        {
            id: 5,
            text: 'Ordenes',
            url: '/Home/Ordenes',
        },
    ],
    Supervisor: [
        {
            id: 5,
            text: 'Ordenes',
            url: '/Home/Ordenes',
        },
        {
            id: 6,
            text: 'Facturas',
            url: '/Home/Facturas',
        },
    ]
}


