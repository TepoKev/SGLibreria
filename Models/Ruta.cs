using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(128, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Nombre { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
        public virtual ICollection<Imagen> Imagen { get; set; }
    }
}
