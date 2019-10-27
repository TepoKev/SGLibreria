using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Detallecompra
    {
        public Detallecompra()
        {
            Kardex = new HashSet<Kardex>();
        }

        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int Cantidad { get; set; }
        public int IdPrecioCompra { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Preciocompra IdPrecioCompraNavigation { get; set; }
        public virtual ICollection<Kardex> Kardex { get; set; }
    }
}
