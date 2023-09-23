using Domain.Entities;

namespace Domain.DTO.Request.Orden
{
    public class OrdenRegistrarRequest: OrdenEntity
    {
        public List<OrdenItemEntity>? ListOrdenItem { get; set; }

    }
}
