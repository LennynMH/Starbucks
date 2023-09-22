using AutoMapper;
using Domain.DTO.Request.ItemMateriaPrima;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperItemMateriaPrima : Profile
    {
        public AutoMapperItemMateriaPrima()
        {
            //AutoMapperItemMateriaPrima
            CreateMap<ItemMateriaPrimaEntity, ItemMateriaPrimaRegisrtarRequest>()
              .ForPath(des => des.IdItem, opt => opt.MapFrom(src => src.Item.IdItem))
              .ForPath(des => des.IdMateriaPrima, opt => opt.MapFrom(src => src.MateriaPrima.IdMateriaPrima))
          ;
        }
    }
}
