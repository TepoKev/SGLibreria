using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Imagen
    {
        public Imagen()
        {
            Producto = new HashSet<Producto>();
            Usuario = new HashSet<Usuario>();
            Tiposervicio = new HashSet<Tiposervicio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdRuta { get; set; }

        public virtual Ruta IdRutaNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Tiposervicio> Tiposervicio { get; set; }
    }
}
