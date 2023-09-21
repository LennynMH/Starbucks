using AutoMapper;
using Domain.DTO.Request.MateriaPrima;
using Domain.DTO.Response.MateriaPrima;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperMateriaPrima : Profile
    {
        public AutoMapperMateriaPrima()
        {
            //MateriaPrima
            CreateMap<MateriaPrimaEntity, MateriaPrimaListarResponse>();
            //CreateMap<EstadoEntity, EstadoListarByIdResponse>();
            //CreateMap<EstadoRegistrarResquest, EstadoEntity>();
            //CreateMap<EstadoActualizarRequest, EstadoEntity>();
            CreateMap<MateriaPrimaEliminarRequest, MateriaPrimaEntity>();
        }
    }
}
