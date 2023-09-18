﻿namespace Domain.Constants
{
    public static class ConstStoreProcedure
    {

        public static class Usuario
        {
            public const string USP_SELECT_USUARIO_BY_CODIGO = "USP_SELECT_USUARIO_BY_CODIGO";
            public const string USP_CREATE_USUARIO = "USP_CREATE_USUARIO";
            public const string USP_UPDATE_USUARIO = "USP_UPDATE_USUARIO";
            public const string USP_DELETE_USUARIO = "USP_DELETE_USUARIO";
            public const string USP_SELECT_USUARIO = "USP_SELECT_USUARIO";
            public const string USP_SELECT_USUARIO_BY_ID = "USP_SELECT_USUARIO_BY_ID";
        }
        public static class Rol
        {
            public const string USP_CREATE_ROL = "USP_CREATE_ROL";
            public const string USP_UPDATE_ROL = "USP_UPDATE_ROL";
            public const string USP_DELETE_ROL = "USP_DELETE_ROL";
            public const string USP_SELECT_ROL = "USP_SELECT_ROL";
            public const string USP_SELECT_ROL_BY_ID = "USP_SELECT_ROL_BY_ID";
        }
        public static class Estado
        {
            public const string USP_CREATE_ESTADO = "USP_CREATE_ESTADO";
            public const string USP_UPDATE_ESTADO = "USP_UPDATE_ESTADO";
            public const string USP_DELETE_ESTADO = "USP_DELETE_ESTADO";
            public const string USP_SELECT_ESTADO = "USP_SELECT_ESTADO";
            public const string USP_SELECT_ESTADO_BY_ID = "USP_SELECT_ESTADO_BY_ID";
        }
        public static class Item
        {
            public const string USP_CREATE_ITEMS = "USP_CREATE_ITEMS";
            public const string USP_UPDATE_ITEMS = "USP_UPDATE_ITEMS";
            public const string USP_DELETE_ITEMS = "USP_DELETE_ITEMS";
            public const string USP_SELECT_ITEMS = "USP_SELECT_ITEMS";
            public const string USP_SELECT_ITEMS_BY_ID = "USP_SELECT_ITEMS_BY_ID";
        }
        public static class Acceso
        {
            public const string USP_SELECT_USUARIO_BY_ACCESO = "USP_SELECT_USUARIO_BY_ACCESO";
        }
    }
}
