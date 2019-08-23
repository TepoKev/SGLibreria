using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Telefono
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string Numero { get; set; }
        public int Tipo { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
    }
}
