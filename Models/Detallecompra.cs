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
        public int IdProducto { get; set; }
        public decimal PrecioCompra { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<Kardex> Kardex { get; set; }
    }
}