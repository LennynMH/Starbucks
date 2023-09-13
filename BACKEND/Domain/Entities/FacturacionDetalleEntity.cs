using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FacturacionDetalleEntity
    {
        public int IdFacturacionDetalle { get; set; }
        public FacturacionEntity? Facturacion { get; set; }
        public OrdenEntity?  Orden { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
    }
}
