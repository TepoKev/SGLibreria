using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Bitacora
    {
        public Bitacora()
        {
            Acciones = new HashSet<Accion>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime InicioSesion { get; set; }
        public DateTime CierreSesion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Accion> Acciones { get; set; }
    }
}
