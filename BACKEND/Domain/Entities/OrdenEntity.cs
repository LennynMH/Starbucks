using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrdenEntity
    {
        public int IdOrden { get; set; }
        public UsuarioEntity? Usuario { get; set; }
        public UsuarioEntity? Empleado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EstadoEntity ?  Estado { get; set; }
        public int TiempoOrden { get; set; }

        public List<OrdenItemEntity>? OrdenItem { get;}
    }
}
