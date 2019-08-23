using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Detalleservicio = new HashSet<Detalleservicio>();
        }

        public int Id { get; set; }
        public int IdTipo { get; set; }
        public float Precio { get; set; }
        public sbyte Estado { get; set; }
        public int IdCompania { get; set; }

        public virtual Compania IdCompaniaNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ICollection<Detalleservicio> Detalleservicio { get; set; }
    }
}
