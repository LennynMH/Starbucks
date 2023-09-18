namespace Domain.Entities
{
    public class ItemEntity
    {
        public int IdItem { get; set; }
        public string? Descripcion { get; set; }
        public decimal Costo { get; set; }
        public bool Activo { get; set; }

    }
}
