using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Telefono
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string Numero { get; set; }
        public sbyte Principal { get; set; }
        public Telefono(int IdProveedor, string Numero, sbyte Principal)
        {
            this.IdProveedor = IdProveedor;
            this.Numero = Numero;
            this.Principal = Principal;
        }
        public Telefono()
        {
        }
        public virtual Proveedor IdProveedorNavigation { get; set; }
    }
}
