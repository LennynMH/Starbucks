﻿namespace Domain.Entities
{
    public class OrdenItemEntity
    {
        public int IdOrdenItem { get; set; }
        public OrdenEntity?  Orden { get; set; }
        public MateriaPrimaEntity?  MateriaPrima { get; set; }
        public int TiempoItem { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
