using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Documento
    {
        public int Id { get; set; }
        public int IdRuta { get; set; }
        public int IdCompra { get; set; }
        public string Nombre { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Ruta IdRutaNavigation { get; set; }
    }
}
