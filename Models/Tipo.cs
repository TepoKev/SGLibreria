using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Servicio = new HashSet<Servicio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
