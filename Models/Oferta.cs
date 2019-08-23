using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Oferta
    {
        public Oferta()
        {
            Ofertaproducto = new HashSet<Ofertaproducto>();
        }

        public int Id { get; set; }
        public sbyte Activo { get; set; }
        public double Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Ofertaproducto> Ofertaproducto { get; set; }
    }
}
