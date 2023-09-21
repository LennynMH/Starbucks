namespace Domain.Entities
{
    public class ItemMateriaPrimaEntity
    {
        public int IdItemMateriPrima { get; set; }
        public MateriaPrimaEntity? MateriaPrima { get; set; }
        public ItemEntity? Item { get; set; }
        public decimal Precio { get; set; }
    }
}
