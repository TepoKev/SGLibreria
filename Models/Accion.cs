using System;
using System.ComponentModel.DataAnnotations;

namespace SGLibreria.Models
{
    public partial class Accion
    {
        public int Id { get; set; }
        public int IdBitacora { get; set; }
        [Display(Name="Descripción"), StringLength(70, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Descripcion { get; set; }
        public DateTime Hora { get; set; }

        public virtual Bitacora IdBitacoraNavigation { get; set; }
    }
}
