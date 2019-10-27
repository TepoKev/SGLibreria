using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Tiposervicio
    {
        public Tiposervicio()
        {
            Detalleservicio = new HashSet<Detalleservicio>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage="El {0} es obligatorio"), StringLength(50, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        public int IdServicio { get; set; }
        [Required(ErrorMessage="El {0} es obligatorio")]
        public decimal Precio { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; }
        public virtual ICollection<Detalleservicio> Detalleservicio { get; set; }
    }
}
