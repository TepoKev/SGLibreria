using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacora = new HashSet<Bitacora>();
            Compra = new HashSet<Compra>();
            Recuperacioncuenta = new HashSet<Recuperacioncuenta>();
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public int? IdImagen { get; set; }
        [Display(Name="Nombre de Usuario"), StringLength(20, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public int Privilegio { get; set; }
        [Required(ErrorMessage="El campo {0} es obligatorio"), Display(Name="Correo Electrónico"), StringLength(50, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Correo { get; set; }
        [Required(ErrorMessage="El campo {0} es obligatorio"), Display(Name="Contraseña"), StringLength(300, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Clave { get; set; }
        public sbyte Estado { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Recuperacioncuenta> Recuperacioncuenta { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
