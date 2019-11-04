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
        [Required(ErrorMessage="El {0} es obligatorio")]
        public double Descuento { get; set; }
        [Display(Name="Fecha de Inicio"), DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [Display(Name="Fecha de Finalización"), DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        public virtual ICollection<Ofertaproducto> Ofertaproducto { get; set; }
    }
}
