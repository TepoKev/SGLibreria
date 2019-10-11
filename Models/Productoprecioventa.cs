using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Productoprecioventa
    {
        public Productoprecioventa()
        {
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Id { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
    }
}
