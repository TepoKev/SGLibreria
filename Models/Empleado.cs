using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Compra = new HashSet<Compra>();
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        [Display(Name="Fecha de Nacimiento"), DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name="Fecha de Ingreso"), DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [Display(Name="DUI")]
        public string Dui { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal Salario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
