using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Detalleservicio
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public int IdServicio { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}
