using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Detallecompra = new HashSet<Detallecompra>();
        }

        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string Factura { get; set; }
        public int TipoCompra { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
    }
}
