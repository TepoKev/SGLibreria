using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Tiposervicio = new HashSet<Tiposervicio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }
        public virtual ICollection<Tiposervicio> Tiposervicio { get; set; }
    }
}
