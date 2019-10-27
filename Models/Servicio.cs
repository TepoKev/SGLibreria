using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Tiposervicio = new HashSet<Tiposervicio>();
        }

        public int Id { get; set; }
        public int? IdImagen { get; set; }
        [Required(ErrorMessage="El {0} es obligatorio"), StringLength(20, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }
        public sbyte Estado { get; set; }
        public int? IdCompania { get; set; }

        public virtual Compania IdCompaniaNavigation { get; set; }
        public virtual Imagen IdImagenNavigation { get; set; }
        public virtual ICollection<Tiposervicio> Tiposervicio { get; set; }
    }
}
