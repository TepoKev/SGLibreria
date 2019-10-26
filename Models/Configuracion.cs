using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Configuracion
    {
        public int Id { get; set; }
        public string NombreInstitucion { get; set; }
        public string Logo { get; set; }
        public int TiempoSesion { get; set; }
    }
}
