using AutoMapper;
using Domain.DTO.Request.Item;
using Domain.DTO.Request.Usuario;
using Domain.DTO.Response.Item;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperItem : Profile
    {
        public AutoMapperItem()
        {
            //Item
            CreateMap<ItemEntity, ItemListarResponse>();
            //CreateMap<UsuarioEntity, UsuarioListarByIdResponse>();
            //CreateMap<UsuarioRegistrarRequest, UsuarioEntity>()
            //    .ForPath(des => des.Rol.IdRol, opt => opt.MapFrom(src => src.IdRol));
            //CreateMap<UsuarioActualizarRequest, UsuarioEntity>()
            //    .ForPath(des => des.Rol.IdRol, opt => opt.MapFrom(src => src.IdRol));
            CreateMap<ItemRegistrarRequest, ItemEntity>();
            CreateMap<ItemEliminarRequest, ItemEntity>();
        }
    }

}
