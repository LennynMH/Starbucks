namespace Domain.Entities
{
    public class OrdenEntity
    {
        public int IdOrden { get; set; }
        public string? NumeroOrden { get; set; }

        //quien crea la orden
        public UsuarioEntity? Usuario { get; set; }

        // quien toma la orden para atenderla
        public UsuarioEntity? Empleado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EstadoEntity? Estado { get; set; }
        public int TiempoOrden { get; set; }

        public List<OrdenItemEntity>? OrdenItem { get; }

        //public OrdenEntity()
        //{
        //    this.OrdenItem = new List<OrdenItemEntity>();
        //}
    }
}
