using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Detalleservicio = new HashSet<Detalleservicio>();
            Tiposervicio = new HashSet<Tiposervicio>();
        }

        public int Id { get; set; }
        public int? IdImagen { get; set; }
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }
        public int? IdCompania { get; set; }
        public int IdTipoServicio { get; set; }

        public virtual Compania IdCompaniaNavigation { get; set; }
        public virtual Imagen IdImagenNavigation { get; set; }
        public virtual ICollection<Detalleservicio> Detalleservicio { get; set; }
        public virtual ICollection<Tiposervicio> Tiposervicio { get; set; }
    }
}
