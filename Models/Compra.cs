using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Detallecompra = new HashSet<Detallecompra>();
            Documento = new HashSet<Documento>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        [Display(Name = "Proveedor")]
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Detallecompra> Detallecompra { get; set; }
        public virtual ICollection<Documento> Documento { get; set; }
    }
}
