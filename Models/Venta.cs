using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Detalleservicio = new HashSet<Detalleservicio>();
            Detalleventa = new HashSet<Detalleventa>();
        }

        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<Detalleservicio> Detalleservicio { get; set; }
        public virtual ICollection<Detalleventa> Detalleventa { get; set; }
    }
}
