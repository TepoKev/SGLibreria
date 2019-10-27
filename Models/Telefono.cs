using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Telefono
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        [Display(Name = "Número"), StringLength(15, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Numero { get; set; }
        public sbyte Principal { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
    }
}
