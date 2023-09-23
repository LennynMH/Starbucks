namespace Domain.DTO.Request.OrdenItem
{
    public class OrdenItemRegistrarRequest
    {
        public int IdOrdenItem { get; set; }
        public int IdItem { get; set; }
        public int TiempoItem { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
