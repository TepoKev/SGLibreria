using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Oferta
    {
        public Oferta()
        {
            Ofertaproducto = new HashSet<Ofertaproducto>();
        }

        public int Id { get; set; }
        public double Descuento { get; set; }
        [Display(Name="Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }
        [Display(Name="Fecha de Finalización")]
        public DateTime FechaFin { get; set; }

        public virtual ICollection<Ofertaproducto> Ofertaproducto { get; set; }
    }
}
