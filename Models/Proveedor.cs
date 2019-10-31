using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Compra = new HashSet<Compra>();
            Telefono = new HashSet<Telefono>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage="El {0} es obligatorio"), StringLength(40, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Dirección"), StringLength(300, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Direccion { get; set; }
        [Display(Name = "Correo Electrónico"), StringLength(50, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres"), EmailAddress(ErrorMessage="Lo ingresado en el campo {0} es inválido")]
        public string Correo { get; set; }
        [Display(Name = "Dirección Web"), StringLength(256, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Enlace { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Telefono> Telefono { get; set; }
    }
}
