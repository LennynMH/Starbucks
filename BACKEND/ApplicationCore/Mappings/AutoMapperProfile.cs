using AutoMapper;
using Domain.DTO.Response.Rol;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //source mapping to destination
            CreateMap<RolEntity, RolListarDto>();
            CreateMap<RolEntity, RolListarByIdDto>(); 
            
            CreateMap<RolRegistrar , RolEntity>();
            CreateMap<RolActualizar, RolEntity>();
            CreateMap<RolEliminar, RolEntity>();

        }
    }
}
