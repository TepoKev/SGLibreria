using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Imagen
    {
        public Imagen()
        {
            Producto = new HashSet<Producto>();
            Servicio = new HashSet<Servicio>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdRuta { get; set; }

        public virtual Ruta IdRutaNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Servicio> Servicio { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
