using Domain.Entities;

namespace Domain.DTO.Response.Item
{
    public class ItemListarByIdResponse
    {
        public ItemEntity? Item { get; set; }
        public List<ItemMateriaPrimaEntity>? ItemMateriaPrima { get; set; }
    }
}
