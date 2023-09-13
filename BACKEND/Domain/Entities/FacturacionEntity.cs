namespace Domain.Entities
{
    public class FacturacionEntity
    {
        public int IdFacturacion { get; set; }
        public OrdenEntity? Orden { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
