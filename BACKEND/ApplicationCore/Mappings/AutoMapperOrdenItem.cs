using AutoMapper;
using Domain.DTO.Request.OrdenItem;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class AutoMapperOrdenItem : Profile
    {
        public AutoMapperOrdenItem()
        {
            //OrdenItem
            CreateMap<OrdenItemEntity, OrdenItemRegistrarRequest>()
              .ForPath(des => des.IdItem, opt => opt.MapFrom(src => src.Item.IdItem))
          ;
        }
    }
}
