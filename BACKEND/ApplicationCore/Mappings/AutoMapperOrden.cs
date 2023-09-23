using AutoMapper;
using Domain.DTO.Request.Orden;
using Domain.DTO.Response.Orden;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperOrden : Profile
    {
        public AutoMapperOrden()
        {
            //Orden
            CreateMap<OrdenEntity, OrdenListarResponse>();
            CreateMap<OrdenRegistrarRequest, OrdenEntity>();
            CreateMap<OrdenEliminarRequest, OrdenEntity>();
        }
    }
}
