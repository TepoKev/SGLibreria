using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Bitacora
    {
        public Bitacora()
        {
            Accion = new HashSet<Accion>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        [Display(Name="InicioSesión")]
        public DateTime InicioSesion { get; set; }
        [Display(Name="CierreSesión")]
        public DateTime CierreSesion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Accion> Accion { get; set; }
    }
}
