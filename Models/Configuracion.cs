using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Configuracion
    {
        public int Id { get; set; }
        [Display(Name="Nombre de la Institución"), StringLength(50)]
        public string NombreInstitucion { get; set; }
        [StringLength(256)]
        public string Logo { get; set; }
        [Display(Name="Tiempo de Sesión")]
        public int TiempoSesion { get; set; }
    }
}
