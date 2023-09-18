using AutoMapper;
using Domain.DTO.Response.Acceso;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperAcceso : Profile
    {
        public AutoMapperAcceso()
        {
            //Usuario
            CreateMap<UsuarioEntity, AccesoValidaUsuarioResponse>();
        }
    }
}
