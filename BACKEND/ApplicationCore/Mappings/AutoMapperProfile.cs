using AutoMapper;
using Domain.DTO.Response.Estado;
using Domain.DTO.Response.Rol;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Rol
            CreateMap<RolEntity, RolListarDto>();
            CreateMap<RolEntity, RolListarByIdDto>(); 
            CreateMap<RolRegistrar , RolEntity>();
            CreateMap<RolActualizar, RolEntity>();
            CreateMap<RolEliminar, RolEntity>();

            //Estado
            CreateMap<EstadoEntity, EstadoListarDto>();
            CreateMap<EstadoEntity, EstadoListarByIdDto>();
            CreateMap<EstadoRegistrar, EstadoEntity>();
            CreateMap<EstadoActualizar, EstadoEntity>();
            CreateMap<EstadoEliminar, EstadoEntity>();
        }
    }
}
