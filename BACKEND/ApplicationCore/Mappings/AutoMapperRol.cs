using AutoMapper;
using Domain.DTO.Request.Rol;
using Domain.DTO.Response.Rol;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperRol : Profile
    {
        public AutoMapperRol()
        {
            //Rol
            CreateMap<RolEntity, RolListarResponse>();
            CreateMap<RolEntity, RolListarByIdResponse>();
            CreateMap<RolRegistrarRequest, RolEntity>();
            CreateMap<RolActualizarRequest, RolEntity>();
            CreateMap<RolEliminarRequest, RolEntity>();
        }
    }
}
