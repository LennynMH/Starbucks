using AutoMapper;
using Domain.DTO.Request.Usuario;
using Domain.DTO.Response.Usuario;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperUsuario : Profile
    {
        public AutoMapperUsuario()
        {
            //Usuario
            CreateMap<UsuarioEntity, UsuarioListarByCodigoResponse>();

            CreateMap<UsuarioEntity, UsuarioListarResponse>();
            CreateMap<UsuarioEntity, UsuarioListarByIdResponse>();
            CreateMap<UsuarioRegistrarRequest, UsuarioEntity>()
                .ForPath(des => des.Rol.IdRol, opt => opt.MapFrom(src => src.IdRol));
            CreateMap<UsuarioActualizarRequest, UsuarioEntity>()
                .ForPath(des => des.Rol.IdRol, opt => opt.MapFrom(src => src.IdRol));
            CreateMap<UsuarioEliminarRequest, UsuarioEntity>();
        }
    }

}
