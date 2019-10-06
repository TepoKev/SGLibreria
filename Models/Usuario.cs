using System;
using System.Collections.Generic;

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
        public string Nombre { get; set; }
        public int Privilegio { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public sbyte Estado { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Recuperacioncuenta> Recuperacioncuenta { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
