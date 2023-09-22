namespace Domain.DTO.Request.ItemMateriaPrima
{
    public class ItemMateriaPrimaRegisrtarRequest
    {
        public int IdItemMateriPrima { get; set; }
        public int IdMateriaPrima { get; set; }
        public int IdItem { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
