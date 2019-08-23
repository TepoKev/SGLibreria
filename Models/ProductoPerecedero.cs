using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class ProductoPerecedero
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
