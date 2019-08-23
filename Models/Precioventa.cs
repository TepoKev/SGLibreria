using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Precioventa
    {
        public Precioventa()
        {
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Id { get; set; }
        public int IdProductoKardex { get; set; }
        public float Precio { get; set; }
        public sbyte Estado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Kardex IdProductoKardexNavigation { get; set; }
        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
    }
}
