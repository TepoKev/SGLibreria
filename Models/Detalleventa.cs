using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Detalleventa
    {
        public Detalleventa()
        {
            Kardex = new HashSet<Kardex>();
        }

        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
        public virtual ICollection<Kardex> Kardex { get; set; }
    }
}
