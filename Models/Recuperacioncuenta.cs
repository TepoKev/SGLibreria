using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Recuperacioncuenta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaRecuperacion { get; set; }
        public sbyte Estado { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
