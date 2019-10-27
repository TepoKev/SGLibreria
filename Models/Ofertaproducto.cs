using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Ofertaproducto
    {
        public int Id { get; set; }
        public int IdOferta { get; set; }
        public int IdProducto { get; set; }
        [Required(ErrorMessage="La {0} es oblogatoria")]
        public int Cantidad { get; set; }

        public virtual Oferta IdOfertaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
