using Domain.Entities;

namespace Domain.DTO.Request.Item
{
    public class ItemRegistrarRequest : ItemEntity
    {
        public List<ItemMateriaPrimaEntity>? ListItemMateriaPrimaEntity { get; set; }
    }
}
