using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Dui { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int IdUsuario { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
