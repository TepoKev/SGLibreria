using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SGLibreria.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        [DisplayName("Género")]
        public int Genero { get; set; }
        public string Direccion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
