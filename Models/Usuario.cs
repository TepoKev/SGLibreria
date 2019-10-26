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
        public int IdEmpleado { get; set; }
        public int? IdImagen { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Este campo solo puede constar de 20 caracteres")]
        public string Nombre { get; set; }
        [Required]
        public int Privilegio { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Este campo solo puede constar de 50 caracteres")]
        public string Correo { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Este campo solo puede constar de 300 caracteres")]
        public string Clave { get; set; }
        public sbyte Estado { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Recuperacioncuenta> Recuperacioncuenta { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
