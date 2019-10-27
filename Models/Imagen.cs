using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Imagen
    {
        public Imagen()
        {
            Producto = new HashSet<Producto>();
            Servicio = new HashSet<Servicio>();
        }

        public int Id { get; set; }
        [StringLength(256, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        public int IdRuta { get; set; }

        public virtual Ruta IdRutaNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
