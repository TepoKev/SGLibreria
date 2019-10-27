using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Preciocompra
    {
        public Preciocompra()
        {
            Detallecompra = new HashSet<Detallecompra>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage="La {0} es oblogatoria")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage="El {0} es oblogatorio")]
        public decimal Valor { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
    }
}
