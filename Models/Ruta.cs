using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            Imagen = new HashSet<Imagen>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Imagen> Imagen { get; set; }
    }
}
