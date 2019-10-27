using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Recuperacioncuenta
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        [Display(Name="Fecha de Envío")]
        public DateTime FechaEnvio { get; set; }
        public string Codigo { get; set; }
        [Display(Name="Fecha de Recuperación")]
        public DateTime FechaRecuperacion { get; set; }
        public sbyte Estado { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
