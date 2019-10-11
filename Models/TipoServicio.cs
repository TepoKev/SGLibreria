using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Tiposervicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdServicio { get; set; }
        public decimal Precio { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; }
    }
}
