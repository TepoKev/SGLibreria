using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            Documento = new HashSet<Documento>();
            Imagen = new HashSet<Imagen>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
        public virtual ICollection<Imagen> Imagen { get; set; }
    }
}
