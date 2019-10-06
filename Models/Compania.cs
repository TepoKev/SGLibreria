using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Compania
    {
        public Compania()
        {
            Servicio = new HashSet<Servicio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
