using System;
using System.Collections.Generic;

namespace SGLibreria.Models
{
    public partial class Imagen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdRuta { get; set; }

        public virtual Ruta IdRutaNavigation { get; set; }
    }
}
