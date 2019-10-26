using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Accion
    {
        public int Id { get; set; }
        public int IdBitacora { get; set; }
        [Display(Name="Descripción"), StringLength(70)]
        public string Descripcion { get; set; }
        public DateTime Hora { get; set; }

        public virtual Bitacora IdBitacoraNavigation { get; set; }
    }
}
