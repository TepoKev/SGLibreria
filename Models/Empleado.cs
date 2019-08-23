using System;
using System.Collections.Generic;

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
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Dui { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal Salario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }

        public byte edad()
        {
            DateTime nacimiento = this.FechaNacimiento; //Fecha de nacimiento
            byte edad =(byte)(DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1);//Edad
            return  edad;
        }
    }
}
