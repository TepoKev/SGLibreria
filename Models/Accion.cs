using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Accion
    {
        public int Id { get; set; }
        public int IdBitacora { get; set; }
        public string Descripcion { get; set; }
        public DateTime Hora { get; set; }

        public virtual Bitacora IdBitacoraNavigation { get; set; }
    }
}
