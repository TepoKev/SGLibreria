using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Preciocompra
    {
        public Preciocompra()
        {
            Detallecompra = new HashSet<Detallecompra>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
    }
}
