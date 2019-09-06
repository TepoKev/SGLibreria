using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class TipoServicio
    {
        public int Id { get; set; }
        [Display(Name = "Servicio")]
        public string Nombre { get; set; }
        public int IdServicio { get; set; }
        public decimal Precio { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; }
    }
}
