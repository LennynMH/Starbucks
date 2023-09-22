using Domain.Entities;

namespace Domain.DTO.Response.Orden
{
    public class OrdenListarByIdResponse
    {
        public OrdenEntity? Orden { get; set; }
        public List<OrdenItemEntity>? OrdenItem { get; set; }
    }
}
