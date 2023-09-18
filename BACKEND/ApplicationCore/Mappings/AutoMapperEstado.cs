using AutoMapper;
using Domain.DTO.Request.Estado;
using Domain.DTO.Response.Estado;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperEstado : Profile
    {
        public AutoMapperEstado()
        {
            //Estado
            CreateMap<EstadoEntity, EstadoListarResponse>();
            CreateMap<EstadoEntity, EstadoListarByIdResponse>();
            CreateMap<EstadoRegistrarResquest, EstadoEntity>();
            CreateMap<EstadoActualizarRequest, EstadoEntity>();
            CreateMap<EstadoEliminarRequest, EstadoEntity>();
        }
    }
}
