using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Compania
    {
        public Compania()
        {
            Servicio = new HashSet<Servicio>();
        }

        public int Id { get; set; }
        [StringLength(20, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
