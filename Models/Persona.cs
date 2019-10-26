using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public int Genero { get; set; }
        public string Direccion { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
