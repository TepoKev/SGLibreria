using System;
using System.ComponentModel.DataAnnotations;
namespace SGLibreria.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        [Required(ErrorMessage="La {0} es obligatoria"), Display(Name="Fecha de Nacimiento"), DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name="Fecha de Ingreso"), DataType(DataType.Date)]
        public DateTime? FechaIngreso { get; set; }
        [Required(ErrorMessage="El {0} es obligatorio"), Display(Name = "DUI"), StringLength(10, ErrorMessage="El campo {0} no puede contener mas de {1} caracteres")]
        public string Dui { get; set; }
        [Display(Name="Fecha de Salida"), DataType(DataType.Date)]
        public DateTime? FechaSalida { get; set; }
        public int IdUsuario { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
