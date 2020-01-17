using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Kardex
    {
        public int Id { get; set; }
        public int Existencia { get; set; }
        public int? IdDetalleCompra { get; set; }
        public int? IdDetalleVenta { get; set; }
        public int? IdProducto {get;set;}
        public virtual Detallecompra IdDetalleCompraNavigation { get; set; }
        public virtual Detalleventa IdDetalleVentaNavigation { get; set; }
        public virtual Producto IdProductoNavigation {get;set;}
    }
}
